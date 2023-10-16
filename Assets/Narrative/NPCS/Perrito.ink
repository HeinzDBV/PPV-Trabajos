INCLUDE ../globals.ink

{ perrito == 0 : -> main | -> final }

=== main ===
¡Guau guau! #speaker:Perrito #portrait:Perrito #layout:Right
¡Buen chico! #speaker:Prota #portrait:Player #layout:Left
~ guardia += 1 
~ perrito += 1 
-> END

=== final ===
¡Guau guau! #speaker:Perrito #portrait:Perrito #layout:Right
-> END