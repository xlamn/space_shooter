# Space Shooter

A simple 2D game created in Unity for the course "Virtual Intelligent Systems" at UPM.

## Play Instructions

After starting the game from the intro the space ship can be navigated with the following keys.

- `Up` Arrow: Move space ship forwards.
- `Down` Arrow: Move space ship backwards.
- `Left` and `Right` Arrow: Rotate space ship into the correspondant direction`
- `Space`: Shoot bullet.

The goal of the game is to hit as many meteors which fly through the space with bullets in order to rescue the world from a disaster.

If the space ship is hit by the meteor the game starts from the beginning and the score is reset. Each time that happens the score is automatically recorded and if high enough, it will be included into the ranking. The ranking is locally persisted.

To jump back to the intro from the game press the key `ESC`

## Project Structure

Inside the assets folder the following subfolders can be found:

- Prefabs: contains all the prefabs that can be used to create multiple gameObjects with the same attributes.
  - Back Button
  - Bullet
  - Meteor
  - ScoreRow (to display each row in the Ranking scene)
- Scenes: contains all the scenes. The start scene is Intro.
  - Credits
  - Game
  - Intro
  - Ranking
- Scripts: contains all the scripts. The most important ones are listed here.
  - PlayerController: handles all the key inputs of the user.
  - LogicManager / RankingManager / ScoreManager: are superior to manage logic and data throughout different scenes.
  - BulletSpawner / MeteorSpawner: create gameObjects and recycles them.
- Sprites: contains all assets that were used.
