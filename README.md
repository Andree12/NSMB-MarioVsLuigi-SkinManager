# NSMB-MarioVsLuigi-SkinManager
A mod that replaces Mario and Luigi character models with different character models without the need of replacing the mario and luigi prefab files or adding custom characters.

## Discord
https://discord.gg/73duQtkgJ5

## Download
Windows Build: [https://github.com/ipodtouch0218/NSMB-MarioVsLuigi/releases/latest](https://github.com/Andree12/NSMB-MarioVsLuigi-SkinManager/releases/tag/v1.7.1.0-beta)

##  How to create a skin mod
Requirements:
Unity 2022.3.15f1
Basic knowledge of Unity's prefab files, blender, 3D models and materials

0. Open up the project folder with unity 2022.3.15f1
1. Go to the skins folder in assets
2. Go into the ***Mario/Luigi*** folder and you will find a template folder
3. make a copy of the ***Mario/Luigi*** template folder and rename to whatever you want to name your mod and make it a part of a assetbundle named ***Mario/Luigi***Skin_***Name of your mod***.
3. Go into the renamed folder, you will find two folders, small_***Mario/Luigi*** and large_***Mario/Luigi***, they each contain a prefab.
4. Customize the prefabs (for models, at least follow chubby's tutorial on models from the MVL discord server), if these files are using custom textures, materials, and models, place the these files into the renamed folder.
5. Click on asset and select build assetbundles and then click it, a folder called streamingassets will be created
6. Place it into the streamingassets folder of the compiled build of MVL skin manager and then add your mod's name with quotation marks (+ a comma if there's more than one skin name in the  ***Mario/Luigi***SkinList array) into the brackets of the ***Mario/Luigi***SkinList array from Skins.json.
7. Launch the game, go to skin manager section, and then click on the mario/luigi button and then a list show up, click on the name of the skin you added, then test it out by creating a private lobby and starting the game to make sure that the custom skin is successfully loaded, if it didn't load, then there's something wrong with the asset bundle.
