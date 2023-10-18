INCLUDE ../globals.ink

{ panadera == 0 : -> main | -> final }

=== main ===
¿Qué tal joven? ¿Qué lo trae por estos lares? #speaker:Panadera #portrait:Panadera #layout:Right #audio:animal_crossing_mid
+[Aceptar]
¡Me gusta el pan! #speaker:Prota #portrait:Player #layout:Left #audio:celeste_low
->main2

+[Pedir información]
Hola, ¿me cuentas un poco del pueblo? #speaker:Prota #portrait:Player #layout:Left #audio:celeste_low 
->main2

=== main2 ===
¿Qué tal? Es bueno ver a gente nueva en este pueblo, no mucha gente viene a visitar. #speaker:Panadera #portrait:Panadera #layout:Right #audio:animal_crossing_mid
Mi panadería quebrará dentro de poco si no consigo más clientes, y todo por culpa de la tonta leyenda del mago oscuro…

+[Otra vez...]
Ay mi madre... otra vez con esas leyendas locas. Discúlpame... #speaker:Prota #portrait:Player #layout:Left #audio:celeste_low
->main3

+[Curiosidad]
¿El mago oscuro? #speaker:Prota #portrait:Player #layout:Left #audio:celeste_low
->main4

=== main3 ===
Ohh... eso no es... y te estás yendo. #speaker:Panadera #portrait:Panadera #layout:Right #audio:animal_crossing_mid
~ guardia += 1 
~ panadera += 1 
-> END

=== main4 ===
¿Sí sabes la historia no? Había un hombre muy callado en el pueblo, se la pasaba todo el tiempo encerrado en su cabaña. #speaker:Panadera #portrait:Panadera #layout:Right #audio:animal_crossing_mid
Solo Dios sabe lo que haría allí, pero todos los que se acercaban decían que emanaba un horrible olor a químicos.
Un día, el hombre salió a caminar por la plaza principal. Todos nos escondimos en nuestras casas, era muy raro verlo salir.
Me enteré que se encontró con una joven, creo que hija del alcalde de ese entonces…
Cuando salimos otra vez, ni ella ni el hombre estaban a la vista, y nunca más se supo de ellos.
Los rumores dicen que fueron absorbidos por uno de los químicos raros del hombre, otros dicen que se convirtieron en monstruos abominables…
¡Para mí esa leyenda es una tontería!
~ guardia += 1 
~ panadera += 1 
-> END

=== final ===
¡Esa leyenda es una tontería! Cómprame Pan, ese sí es de verdad.#speaker:Panadera #portrait:Panadera #layout:Right #audio:animal_crossing_mid
-> END