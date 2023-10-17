INCLUDE ../globals.ink

{ princesa == 0 : -> main | -> final }


=== main ===
¿No crees que las flores son hermosas aquí?#speaker:Princesa #portrait:Princesa #layout:Right #audio:animal_crossing_low

+[Asentir]
¡Lo son! #speaker:Prota #portrait:Player #layout:Left #audio:celeste_low
->main2

+[Discrepar]
¡No tanto! #speaker:Prota #portrait:Player #layout:Left #audio:celeste_low
->main3

=== main2 ===
¡Gracias! Desde hace tiempo llevo cuidándolas para que crezcan y alegren nuestro pueblo…#speaker:Princesa #portrait:Princesa #layout:Right #audio:animal_crossing_low
-> main4

=== main3 ===
Oh… Está bien, es bueno saberlo, todos los días las riego para que crezcan sanas y fuertes, pero no siempre funciona…#speaker:Princesa #portrait:Princesa #layout:Right #audio:animal_crossing_low
-> main4

=== main4 ===
Veo que eres nuevo por aquí, es extraño, no solemos tener visitantes. #audio:animal_crossing_low
¿No has oído la leyenda del pueblo?

+[Si]
La oí hace mucho tiempo, apenas recuerdo partes. #speaker:Prota #portrait:Player #layout:Left #audio:celeste_low
-> main5

+[No]
No me suena… #speaker:Prota #portrait:Player #layout:Left #audio:celeste_low
-> main6

=== main5 ===
Ohh... ya veo... entonces nos vemos. #speaker:Princesa #portrait:Princesa #layout:Right #audio:animal_crossing_low
~ guardia += 1 
~ princesa += 1 
-> END

=== main6 ===
En cualquier caso te la contaré… #speaker:Princesa #portrait:Princesa #layout:Right #audio:animal_crossing_low
Hace mucho tiempo, hubo una bella princesa en estas tierras.
Ella cantaba y bailaba entre las flores, y todo el mundo quedaba admirado con su belleza.
Entre ellos, hubo un hombre que se ganó su corazón…
Un noble alquimista que la adoraba con locura.
Ambos vivieron felices por mucho tiempo, hasta que llegó la calamidad.
La enfermedad se adueñó de ella, y su brillo de vida se apagaba cada vez más.
El alquimista hizo todo lo posible para salvarla, experimentó con distintos elementos, conjuros prohibidos, fuerzas oscuras…
La princesa quedó irreconocible, y su chispa se apagó por completo.
Desde ese entonces, el alquimista huyó a la cima de las montañas, avergonzado por convertir a su amada en un monstruo sin vida.
+[Wow]
Wow.#speaker:Prota #portrait:Player #layout:Left #audio:celeste_low
-> main7

=== main7 ===
Es una historia un poco turbia, por eso no hay muchos visitantes por aquí. #speaker:Princesa #portrait:Princesa #layout:Right #audio:animal_crossing_low
~ guardia += 1 
~ princesa += 1 
-> END

=== final ===
Espero que algún día sepamos más del pobre alquimista. #speaker:Princesa #portrait:Princesa #layout:Right #audio:animal_crossing_low
-> END