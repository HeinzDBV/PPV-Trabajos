INCLUDE ../globals.ink

{ guardia != 6 : -> main | -> final }

=== main ===
¡Alto! Nadie puede pasar la muralla, si desea regresar a la ciudad, debe esperar el embarcadero más próximo. #speaker:Guardia #portrait:B #layout:Right
-> END
/////////////////////////////////////////////////////////////////////////////////////
=== final ===
Vengo en búsqueda del mago oscuro. #speaker:Prota #portrait:Default #layout:Left
¿El mago oscuro? ¿Estás seguro de que quieres buscarlo? #speaker:Guardia #portrait:B #layout:Right
-> final2

=== final2 ===
Sí, lo venceré. #speaker:Prota #portrait:Default #layout:Left
Debo quedarme aquí protegiendo la muralla, sino yo mismo habría vencido a ese loco. #speaker:Guardia #portrait:B #layout:Right
Pero te ves como alguien valiente. Si logras vencerlo, te estaremos muy agradecidos. #door:true
-> END