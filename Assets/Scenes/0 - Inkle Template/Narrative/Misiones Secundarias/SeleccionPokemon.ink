INCLUDE  ../global.ink

-> main

{ pokemon_name == "": -> main | -> already_chose }

===main===
Que pokemon quieres escoger?
    + [Charmander]
        -> chosen("Charmander")
    + [Bulbasaur]
        -> chosen("Bulbasaur")
    + [Squirtle]
        -> chosen("Squirtle")
        
===chosen(pokemon)=== 
~ pokemon_name = pokemon
You chose {pokemon}!
-> END

=== already_chose ===
Ya escogiste {pokemon_name}!
-> END