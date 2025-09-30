#!/usr/bin/env bash
set -euo pipefail

# Build directory relative to current working dir
BUILD_DIR="${PWD}/sdl3-build"
INSTALL_PREFIX="/usr/local"

# Install required dependencies (Arch Linux package names)
sudo pacman -S --needed --noconfirm \
  base-devel git cmake ninja \
  libpng libjpeg-turbo libwebp freetype2 \
  alsa-lib libpulse pipewire \
  libvorbis libmodplug opusfile flac mpg123

mkdir -p "$BUILD_DIR"
cd "$BUILD_DIR"

clone_and_build() {
  local repo_url=$1
  local dir_name=$2
  shift 2
  if [ ! -d "$dir_name" ]; then
    git clone --depth=1 "$repo_url" "$dir_name"
  else
    cd "$dir_name"
    git pull
    cd ..
  fi

  cmake -B "$dir_name/build" -S "$dir_name" \
    -DCMAKE_BUILD_TYPE=Release \
    -DCMAKE_INSTALL_PREFIX="$INSTALL_PREFIX" \
    "$@"
  cmake --build "$dir_name/build" -j"$(nproc)"
  sudo cmake --install "$dir_name/build"
}

# SDL3 core
clone_and_build https://github.com/libsdl-org/SDL.git SDL

# SDL3_image with PNG/JPG/WebP save support
clone_and_build https://github.com/libsdl-org/SDL_image.git SDL_image \
  -DSDLIMAGE_BACKEND_PNG=ON \
  -DSDLIMAGE_BACKEND_JPG=ON \
  -DSDLIMAGE_BACKEND_WEBP=ON \
  -DSDLIMAGE_INSTALL=ON

# SDL3_ttf (requires freetype2)
clone_and_build https://github.com/libsdl-org/SDL_ttf.git SDL_ttf

# SDL3_net
clone_and_build https://github.com/libsdl-org/SDL_net.git SDL_net

# SDL3_mixer with various codec backends
clone_and_build https://github.com/libsdl-org/SDL_mixer.git SDL_mixer \
  -DSDLMIXER_BACKEND_VORBIS=ON \
  -DSDLMIXER_BACKEND_OPUS=ON \
  -DSDLMIXER_BACKEND_FLAC=ON \
  -DSDLMIXER_BACKEND_MPG123=ON \
  -DSDLMIXER_BACKEND_MOD=ON

echo "✅ SDL3, SDL3_image, SDL3_ttf, SDL3_net, and SDL3_mixer successfully installed to $INSTALL_PREFIX"
echo "👉 If you installed to /usr/local, make sure to update LD_LIBRARY_PATH:"
echo "   export LD_LIBRARY_PATH=$INSTALL_PREFIX/lib:\$LD_LIBRARY_PATH"
