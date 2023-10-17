INCLUDE ../globals.ink

{ 
- guardia <= 5 : -> main 
- guardia == 6: -> final
- else: -> final3
}

=== main ===
¡Alto! Nadie puede pasar la muralla, si desea regresar a la ciudad, debe esperar el embarcadero más próximo. #speaker:Guardia #portrait:Guardia #layout:Right #audio:animal_crossing_mid
-> END
/////////////////////////////////////////////////////////////////////////////////////
=== final ===
Vengo en búsqueda del mago oscuro. #speaker:Prota #portrait:Player #layout:Left #audio:celeste_low
¿El mago oscuro? ¿Estás seguro de que quieres buscarlo? #speaker:Guardia #portrait:Guardia #layout:Right #audio:animal_crossing_mid
-> final2

=== final2 ===
Sí, lo venceré. #speaker:Prota #portrait:Player #layout:Left #audio:celeste_low
Debo quedarme aquí protegiendo la muralla, sino yo mismo habría vencido a ese loco. #speaker:Guardia #portrait:Guardia #layout:Right #audio:animal_crossing_mid
Pero te ves como alguien valiente. Si logras vencerlo, te estaremos muy agradecidos. #door:true 
~ guardia += 1 
-> END

=== final3 ===
Ve, yo defiendo la puerta. #speaker:Guardia #portrait:Guardia #layout:Right #audio:animal_crossing_mid
~ guardia += 1 
-> END