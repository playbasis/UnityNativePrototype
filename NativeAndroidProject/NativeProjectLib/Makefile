# Makefile to automatically build a jar library to destination

SOURCE=bin/nativeprojectlib.jar libs/*.jar
TARGET_BOOTSTRAP=../NativeProjectBootstrap/libs/
TARGET_UNITY=../../UnityProject/Assets/Plugins/Android/bin/
CLASSES_REMOVE=$(TARGET_UNITY)/classes.jar

all:
	ant jar
	echo "copy to bootstrap project"
	cp $(SOURCE) $(TARGET_BOOTSTRAP)
	echo "copy to unity project's Android plugin folder"
	cp $(SOURCE) $(TARGET_UNITY)
	echo "remove classes.jar from destination"
	rm $(CLASSES_REMOVE)
	echo "All done!"
