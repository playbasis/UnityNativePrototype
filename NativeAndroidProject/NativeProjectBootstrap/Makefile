# Makefile to automatically build a jar library to destination
# use 'genkey' to generate signing key to sign result .apk first if you need to install .apk to device or emulator

all:
	ant jar

genkey:
	keytool -genkey -v -keystore release.keystore -alias release.keystore -keyalg RSA -keysize 2048 -validity 100000

release:
	ant release

install:
	adb install -r bin/NativeProjectBootstrap-debug.apk

clean:
	ant clean
