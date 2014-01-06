resharper-reformatutils
=======================

A ReSharper plugin that provides actions and shortcuts for reformatting based on scope (e.g. reformat method)

The plugin provides a "reformat" quick-fix action (alt-enter) for certain elements, such as class, interface, struct.
To use these quick-fixes place the cursor on the element (e.g. on the class name) and use the quick-fix shortcut (alt-enter), you will then see a menu with a Reformat Class entry.

In addition the plugin adds Visual Studio actions for reformatting the current statement and the current method. 
These actions must unfortunately be bound to shortcuts manually due to SDK limitations (can be found under in the Visual Studio main menu line; Tools - Options - Keyboard).
