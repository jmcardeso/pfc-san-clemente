# ESTUDIO DE NECESIDADES Y MODELO DE NEGOCIO

## Justificación de las necesidades detectadas que cubre el sistema a desarrollar

A lo largo de los últimos años cada vez más propietarios de viviendas deshabitadas o en alquiler tradicional se pasan al alquiler vacacional o turístico, por su mayor beneficio económico. Para publicitar sus inmuebles, hacen uso de webs especializadas en este tipo de alquiler -Airbnb o Booking entre muchas otras-, que les permiten acceder a los posibles clientes interesados de cualquier lugar del mundo.

Sin embargo, estas webs están fundamentalmente enfocadas en el cliente y raramente ofrecen al propietario características tan necesarias como la emisión de facturas o la posibilidad de hacer campañas publicitarias u ofertas de forma personalizada.

Ante esta situación, nace Gesalt -gestión de alquileres turísticos-. Gesalt pretende ser una apliación que ayude tanto al pequeño propietario como a las agencias inmobiliarias en la gestión de aquellas tareas que no contemplan las webs antes señaladas. Para ello, hace uso de un doble enfoque que viene marcado por el tipo y la ubicación de la base de datos, pilar fundamental de cualquier aplicación.

Si el usuario es un pequeño propietario, Gesalt puede utilizar una base de datos local alojada en el ordenador en el que se ejecuta el programa; si se trata de una agencia inmobiliaria con varios ordenadores trabajando a la vez, Gesalt puede conectarse con una base de datos ubicada en un servidor remoto.

Esta característica -ser DB Agnostic, esto es, independiente del SGBD- es la piedra angular del programa. Y si bien, inicialmente, sólo están implementados dos SGBD -Access en local, MySQL en remoto-, es posible añadir cualquier otro sin afectar al núcleo del código.

Gesalt está desarrolado en Visual Basic, que une a su facilidad de uso la potencia del framework .NET y del paradigma de la programación orientada a objetos.

Al tratarse del proyecto de fin de ciclo de un único alumno, inicialmente no puede aprovecharse de las ventajas  de la colaboración que ofrecen plataformas como GitLab -donde está alojado-, pero está preparado para hacerlo en un futuro (gestión de incidencias, etc.).

## Posibilidades de comercialización (viabilidad, competidores…).

1.	Viabilidad.

    1.1	Viabilidad técnica.
	
	El proyecto es viable técnicamente. No se necesita más infraestructura que un ordenador con las herramientas necesarias. La única dificultad viene marcada por el tiempo, al ser hecho por un único desarrollador.
        
    1.2	Viabilidad económica
	
	Todas las herramientas necesarias para el desarrollo de la aplicación son gratuítas, tanto el IDE empleado (Visual Studio) como los sistemas gestores de las bases de datos. La única variable económica a tener en cuenta es el tiempo de desarrollo, pero al tratarse de un proyecto de fin de ciclo tampoco se puede considerar.
        
2.	Competencia.

	Existen algunas webs que, pagando una cuota, permiten realizar funciones similares. Algunas incluso tienen un servicio gratuíto, pero muy limitado. Gesalt sería una alternativa gratuíta, de código libre y, por tanto, facilmente adaptable por otros desarrolladores. Para un usuario típico, por ejemplo un pequeño propietario, sería una opción a coste cero para llevar la gestión de su vivienda turística.

## Ideas para su comercialización.

1. Modelo de negocio.

	Gesalt es un programa de código libre, un proyecto de fin de ciclo realizado en un ámbito académico. No obstante, sería viable convertirlo a un modelo freemium, gratuíto para el público general y de pago, por ejemplo, a las inmobiliarias u otras empresas que necesitasen soporte técnico o la puesta a punto de la base de datos en el servidor.

2. Promoción.

	Optando por un modelo freemium, la promoción sería contactando con las agencias y profesionales del sector inmobiliario bien personalmente, bien acudiendo a eventos del sector.

# Webgrafía

Justificación de necesidades, viabilidad:

**Guía para la elaboración de proyectos. Gobierno Vasco.**

https://www.pluralismoyconvivencia.es/upload/19/71/guia_elaboracion_proyectos_c.pdf  (página 26 y siguientes)

Competencia:

**Modelo de plan de negocios. Empresa de servicios informáticos. IGAPE**

http://www.igape.es/images/crear-unha-empresa/Recursos/PlansdeNegocio/16ServiciosInformaticos12_5_cas.pdf 
(página 45 y siguientes)
