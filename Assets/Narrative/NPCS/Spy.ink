INCLUDE ../globals.ink

{ spy == 0 : -> main | -> final }
Vengo en búsqueda del mago oscuro. #speaker:Prota #portrait:Player #layout:Left
¿El mago oscuro? ¿Estás seguro de que quieres buscarlo? #speaker:Spy #portrait:Spy #layout:Right

=== main ===
¡Hey tú! He oído rumores de que quieres ir a la montaña… ¿Tienes idea de lo que te estás involucrando? #speaker:Spy #portrait:Spy #layout:Right

+[Curiosidad]
¿Quién eres? #speaker:Prota #portrait:Player #layout:Left
Soy los ojos y oídos de este pueblo. #speaker:Spy #portrait:Spy #layout:Right
->main2

+[Firmeza]
Sé a lo que me enfrento. #speaker:Prota #portrait:Player #layout:Left
Oh chico… no tienes ni la menor idea. #speaker:Spy #portrait:Spy #layout:Right
->main2

=== main2 ===
Te contaré esto solo por tu bien, ir a la montaña es muerte segura.
Ese muro lleva bloqueando el paso desde que tengo uso de razón, todo aquel que se atrevió a cruzarlo jamás volvió.

+[Héroe]
Quiero salvar al pueblo… #speaker:Prota #portrait:Player #layout:Left
No digas tonterías, el pueblo ya no tiene salvación. #speaker:Spy #portrait:Spy #layout:Right
Dentro de poco nos iremos los pocos que quedamos, y esto será tierra de nadie.
->main3

+[Reto]
Puedo derrotar al monstruo. #speaker:Prota #portrait:Player #layout:Left
¿Monstruo? Ya no estoy seguro que sea un monstruo. #speaker:Spy #portrait:Spy #layout:Right
Es mucho peor de lo que parece, estamos hablando de magia oscura, invocaciones, fuerzas del más allá…
Estamos hablando de un tipo que juega a ser dios contra las fuerzas de la naturaleza… No podrás hacer nada contra él.
->main3

=== main3 ===
¡Quiero ayudar! #speaker:Prota #portrait:Player #layout:Left
Pues si tanto quieres ayudar, ve. Dile al guardia que quieres ver al mago oscuro. Pero no me busques cuando estés convertido en un monstruo come hombres. #speaker:Spy #portrait:Spy #layout:Right
~ guardia += 1 
~ spy += 1 
-> END


=== final ===
No vuelvas por aquí. No me gustaría encariñarme contigo. #speaker:Spy #portrait:Spy #layout:Right
-> END