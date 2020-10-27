# Rhithm
Rhithm is a Procedurally-generated Rhythm game developed for Android using Unity.

## Description
This game is a simple Rhithm game that procedurally generates beatmaps for each playthrough.

## Project Status
This Game has been developed as apart of a University Project, and will unlikely see any future updates. 

## Usage
This game was developed and tested using Unity 2020.1.3f1. 

For desktop gameplay, select the ```Main Menu``` scene.

To add additional songs to the songList, import an AudioClip (preferred formats are .mp3 or .wav), move AudioClip to Assets/Audio/Music Tracks, create AudioSoure GameObject in Assets/Resources/Prefabs/Audio,
drag AudioClip to AudioSource>AudioClip, add component SongObjectScript, drag AudioSource to SongObjectScript>AudioSource, navigate to SongSelectionScript, in Start() instantiate the AudioSource GameObject you just made. 

For adding songs directly into ```Main Gameplay```, create an empty object, attach the ```SongObjectScript``` script to the empty object, add an audio file, and add relevant details i.e. BPM. 

## Contributing

We are open to contributions! But please acknowledge us and all other contributors to the original project when doing so. 

## Authors and Acknowledgment

All Code Samples besides those included from https://github.com/jesse-scam/algorithmic-beat-mapping-unity, and the DSPLIB.cs and Complex.cs were written by Team Rhithm. 

Jesse Kogh is the author of the Algorithmic Beat Mapping, on which our procedural generation is based. 
Jesse Keogh is the Lead Developer / Co-Founder of Giant Scam Industries. https://twitter.com/giantscam

All music by Emperat is available here: https://soundcloud.com/emperat

## License

All code samples besides DSPLib.cs and Complex.cs are covered by the MIT license. See those source files for information about their external licenses.
Example Audio Files by "Emperat" are copyright of Emperat, and while they may be distributed with this project, it may not be further distributed or used without consent. 

