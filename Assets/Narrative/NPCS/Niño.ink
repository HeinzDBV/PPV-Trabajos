INCLUDE ../globals.ink

{ niño == 0 : -> main | -> final }
Vengo en búsqueda del mago oscuro. #speaker:Prota #portrait:Player #layout:Left
¿El mago oscuro? ¿Estás seguro de que quieres buscarlo? #speaker:Niño #portrait:Niño #layout:Right

=== main ===
¿Eres un visitante? No luces como alguien de por aquí. #speaker:Niño #portrait:Niño #layout:Right

+[Aventura]
Vine a buscar aventuras en la montaña. #speaker:Prota #portrait:Player #layout:Left
->main2

+[Cállate Oe]
No es de tu incunbencia niño, vete a llorar con tu madre en algún lado. #speaker:Prota #portrait:Player #layout:Left
->main3

=== main2 ===
Ten cuidado, mamá solo me deja correr cerca de la casa. #speaker:Niño #portrait:Niño #layout:Right
Dice que hay un gran monstruo come niños en la cima de la montaña.
Y que si no como todas mis verduras… ¡el brujo me convertirá en una lombriz!
~ niño += 1 
~ guardia += 1 
-> END

=== main3 ===
... #speaker:Niño #portrait:Niño #layout:Right
~ niño += 1 
~ guardia += 1 
-> END

=== final ===
¡No vayas a ver al brujo! #speaker:Niño #portrait:Niño #layout:Right
-> END