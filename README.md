# MG7
## Devlog
In my `TreeOfBirds` script, I used a `GameObject` array to store the four sparrows that start inactive. I assigned them in the Inspector and left out `Sparrow_Start` because it starts active. Each frame, the script loops through the array and subtracts each inactive bird’s position from the player’s position. This gives a vector from the bird to the player, and its magnitude tells me how far apart they are. When a bird is within the interaction distance, `TreeOfBirds` activates it, and the `Bird` script makes it pop out of the tree.
- [Forest Nature Pack](https://kaylousberg.itch.io/kaykit-forest) - environment 3D models
- [Quirky Series](https://assetstore.unity.com/packages/3d/characters/animals/quirky-series-free-animals-pack-178235) - animal 3D models
