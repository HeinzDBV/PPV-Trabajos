INCLUDE ../globals.ink

{ viejito == 0 : -> main | -> final }
Vengo en búsqueda del mago oscuro. #speaker:Prota #portrait:Player #layout:Left #audio:celeste_low
¿El mago oscuro? ¿Estás seguro de que quieres buscarlo? #speaker:Viejito #portrait:Viejito #layout:Right #audio:celeste_high

=== main ===
¿Qué tal joven? ¿Qué lo trae por estos lares? #speaker:Viejito #portrait:Viejito #layout:Right #audio:celeste_high

+[Aventuras]
¡Vengo a buscar aventuras! #speaker:Prota #portrait:Player #layout:Left #audio:celeste_low
->main2

+[Conquistar]
¡Quiero conquistar el mundo! #speaker:Prota #portrait:Player #layout:Left #audio:celeste_low
->main2

=== main2 ===
Extraño ese entusiasmo de la juventud, ustedes tienen energía para todo ja ja ja.#speaker:Viejito #portrait:Viejito #layout:Right #audio:celeste_high
Pero le aconsejo que vaya a otro pueblo, acá solo encontrará un destino fatal.
Estoy seguro que ya escuchó del monstruo de la montaña…

+[Espera]
Disculpa, tengo que seguir con mi viaje... me voy. #speaker:Prota #portrait:Player #layout:Left #audio:celeste_low
->main3

+[Continua]
Cuénteme más sobre esa historia... #speaker:Prota #portrait:Player #layout:Left #audio:celeste_low
->main4

=== main3 ===
Ohh... está bien. Cuidese joven. #speaker:Viejito #portrait:Viejito #layout:Right #audio:celeste_high
~ guardia += 1 
~ viejito += 1 
-> END

=== main4 ===
Ocurrió hace mucho tiempo, yo solo era un joven en ese entonces.#speaker:Viejito #portrait:Viejito #layout:Right #audio:celeste_high
Teníamos una gran villa llena de árboles, animales y prosperidad.
Éramos famosos por nuestros productos artesanales, y siempre recibíamos visitas de personas curiosas por conocer la belleza del pueblo. 
Pero un día, un gran monstruo empezó a atacar los límites del pueblo.
Destruyó casas, mató niños, se comió a los animales…
Nos vimos en la necesidad de alejarnos de la montaña y construir un muro de protección.
Nadie sabe si el monstruo sigue allá, pero es muy peligroso ir.
Poco a poco, la gente del pueblo se mudaba, no querían vivir al lado de una máquina asesina.
~ guardia += 1 
~ viejito += 1 
-> END

=== final ===
Yo permanezco aquí por mi pequeña granja, y seguiré aquí hasta el final de mis días… #speaker:Viejito #portrait:Viejito #layout:Right #audio:celeste_high
-> END