#!/bin/bash 
# this is a start script for mac
MONO_FRAMEWORK="/Library/Frameworks/Mono.framework/Versions/Current/"
export DYLD_FALLBACK_LIBRARY_PATH="$MONO_FRAMEWORK/lib:/usr/local/lib:/usr/lib"
EXE_DIR=`dirname $0`
mono $MONO_OPTIONS $EXE_DIR/CrossTemplate.exe "$@"