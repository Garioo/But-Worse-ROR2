https://github.com/user-attachments/assets/7fb0f77b-c90c-4e37-9f71-18231b6a8e31

# Mini Project - But Worse Risk Of Rain 2

## Overview of the Game
The idea of this project is a wave-based survival game inspired by Risk of Rain 2’s alternative game mode “Simulacrum.” The player controls a wizard in a 3D environment surrounded by mountains. Using keyboard controls, the player moves freely while the camera follows from a third-person perspective with aiming functionality tied to the mouse. The goal is to survive waves of increasingly challenging enemies by defeating them with fireballs while avoiding their attacks.

Enemies represented as dragons spawn randomly near the player and scale in number, damage, and health as the waves progress. Each wave adds more chaos, with the dragons pursuing the player and attacking with tail whips when in the correct range.

The player has limited health, and the game ends when the wizard’s health reaches zero. While the project excludes features like item collection, varied enemies, and boss fights seen in Risk of Rain 2, it focuses on the core mechanics of wave-based combat and enemy scaling. The aesthetic is inspired by Risk of Rain 2’s low-poly style, with assets sourced from the Unity Asset Store to create a visually pleasing environment.

## Project Parts

- **Player**: A wizard with a base health of 275. Movement is controlled using WASD, with space to jump and shift to sprint. Aiming and firing fireballs are controlled with the mouse. The fireball deals 20 damage upon impact with enemies.
  
- **Camera**: The game uses a third-person camera with a slight offset to the right of the player. Players can aim precisely by holding the right mouse button, making the camera part of the combat system. The smooth camera movement and alignment with the wizard’s aiming enhance immersion and control.

- **Enemies**: Dragons spawn randomly near the player at the start of each wave. They move toward the player using Unity’s NavMesh system and attack with tail whips that deal 2 base damage. Enemy health and damage scale by 5% with each wave.

- **Play Area**: The play area is a valley surrounded by mountains. The player can walk off the map but will fall into the void.

- **Waves**: The wave system is a core mechanic. Each wave spawns an increasing number of enemies with scaling health and damage. New waves spawn after the player clears the current wave or after a set time if the player takes too long to defeat the enemies.

## Game Features

- Enemies are randomly spawned with scaling health and quantity each wave.
- The game becomes progressively harder as more and stronger enemies spawn.
- Enemies chase the player until the wizard dies.

## Scripts

- **BulletTarget**: Applies damage to an Enemy component.
- **CharacterAiming**: Handles third-person aiming, including mouse input, character rotation, and animator updates.
- **PlayerHealth**: Manages the player’s health, updates UI elements related to health.
- **StarterAssetsInputs**: Handles input values for character movement.
- **ThirdPersonController**: Manages movement and rotations of the wizard.
- **ThirdPersonShooter**: Handles aiming, shooting mechanics, and camera control.
- **BulletProjectile**: Manages the fireball’s behavior and applies damage to targets it collides with.
- **Enemy**: Manages the enemy’s health, damage, and attacks.
- **EnemyAi**: Controls the enemy’s behavior, including patrolling, detecting the player, attacking, and animations.
- **EnemySpawner**: Manages the spawning of waves, scaling of enemies and health, and updates the wave number in the UI.
- **BasicRigidBodyPush**: Pushes non-kinematic rigidbodies upon collision and applies force based on direction and strength.

## Models & Prefabs

- **Dragon**: Asset from the Unity Asset Store (AssetStore.unity)
- **Wizard**: Asset from the Unity Asset Store (AssetStore.unity)
- **Terrain**: Asset from the Unity Asset Store (AssetStore.unity)
- **Fireball**: Made with Unity Particle System and VFX Graph.

## Task Breakdown

| Task | Time it Took (in hours) |
| --- | --- |
| Setting up Unity | 0.5 |
| Research and finding the concept of the "but worse" idea | 1.5 |
| Searching for 3D models | 1 |
| Building Particle | 1.5 |
| Making camera movement | 0.5 |
| Player movement | 1 |
| Creating third-person movement with camera | 2 |
| Building the shooting of fireball and instantiating it from a point | 2.5 |
| Creating NavMesh and enemy AI | 1 |
| Building random spawning and wave system | 2 |
| Creating player and enemy data | 1 |
| Creating attack and damage behavior | 1.5 |
| Creating an animator for player and enemies | 0.5 |
| Bug fixing | 1 |
| Code documentation | 1 |
| Making README | 1 |
| **Total Time** | **19.5** |

## References
- [Particle Fireball](https://www.youtube.com/watch?v=RsWw99JDXdY)
- [Third-Person Aiming](https://unitycodemonkey.com/video.php?v=FbM4CkqtOuA)
- [NavMesh AI](https://www.youtube.com/watch?v=2yH41kSFG8I)
- [Enemy Spawner](https://devsourcehub.com/setting-up-basic-enemy-spawning-in-unity/)
- [Third Person Controller](https://assetstore.unity.com/packages/essentials/starter-assets-thirdperson-updates-in-new-charactercontroller-pa-196526)
