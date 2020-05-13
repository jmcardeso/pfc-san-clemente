# ESTUDIO DE NECESIDADES Y MODELO DE NEGOCIO

## Justificación de las necesidades detectadas que cubre el sistema a desarrollar

A lo largo de los últimos años cada vez más propietarios de viviendas deshabitadas o en alquiler tradicional se pasan al alquiler vacacional o turístico, por su mayor beneficio económico. Para publicitar sus inmuebles, hacen uso de webs especializadas en este tipo de alquiler -Airbnb o Booking entre muchas otras-, que les permiten acceder a los posibles clientes interesados de cualquier lugar del mundo.

Sin embargo, estas webs están fundamentalmente enfocadas en el cliente y raramente ofrecen al propietario características tan necesarias como la emisión de facturas o la posibilidad de hacer campañas publicitarias u ofertas de forma personalizada.

Ante esta situación, nace Gesalt -gestión de alquileres turísticos-. Gesalt pretende ser una apliación que ayude tanto al pequeño propietario como a las agencias inmobiliarias en la gestión de aquellas tareas que no contemplan las webs antes señaladas. Para ello, hace uso de un doble enfoque que viene marcado por el tipo y la ubicación de la base de datos, pilar fundamental de cualquier aplicación.

Si el usuario es un pequeño propietario, Gesalt puede utilizar una base de datos local alojada en el ordenador en el que se ejecuta el programa; si se trata de una agencia inmobiliaria con varios ordenadores trabajando a la vez, Gesalt puede conectarse con una base de datos ubicada en un servidor remoto.

Esta característica -ser DB Agnostic, esto es, independiente del SGBD- es la piedra angular del programa. Y si bien, inicialmente, sólo están implementados dos SGBD -Access en local, MySQL en remoto-, es posible añadir cualquier otro sin afectar al núcleo del código.

Gesalt está desarrolado en Visual Basic, que une a su facilidad de uso la potencia del framework .NET y del paradigma de la programación orientada a objetos.

Al tratarse del proyecto de fin de ciclo de un único alumno, inicialmente no puede aprovecharse de las ventajas  de la colaboración que ofrecen plataformas como GitLab -donde está alojado-, pero está preparado para hacerlo en un futuro (gestión de incidencias, etc.).

## Posibilidades de comercialización (viabilidade, competidores…).
1.	Viabilidade.

    1.1	Viabilidade técnica.
    
        1.1.a) Será posible dispoñer dos recursos humanos e medios de produción necesarios (materias primas, maquinaria, instalacións…)?
        
        1.1.b) Existe algún impedimento técnico que dificulte o proceso produtivo?
        
    1.2	Viabilidade económica
    
        1.2.a) Os beneficios do proyecto son superiores aos costes?
        
        1.2.b) As perdas poden cubrirse vía financiamento (por parte da administración pública, con subvencións, etc)?
        
2.	Competencia.

    2.1. Identificación da competencia, as súas características e a súa posición no mercado.
    
    2.2. Existencia de productos/servizos substitutivos.

## Ideas para a súa comercialización.
1.	Promoción.

    1.1.	Técnicas elixidas (redes sociais, plataformas multimedia, páxina web, posicionamento web SEO, patrocinios, participación en eventos, prácticas de responsabilidade social corporativa, outras).
    
    1.2.	Xustifica a elección.
    
2.	Modelo de negocio.

    2.1.Modelo elixido (Modelo de pago / Freemium (é de balde pero as funcionalidades extras son de pago) / In house (desenvolvementos a medida para contornos empresariais / De subscrición / Por publicidade / Outros)
    
    2.2. Xustifica a elección.

# Webgrafía

Xustificación de necesidades, viabilidade:

**Guía para a elaboración de proyectos. Gobierno Vasco.**

https://www.pluralismoyconvivencia.es/upload/19/71/guia_elaboracion_proyectos_c.pdf  (páxina 26 e seguintes)

Competencia:

**Modelo de plan de negocios. Empresa de servicios informáticos. IGAPE**

http://www.igape.es/images/crear-unha-empresa/Recursos/PlansdeNegocio/16ServiciosInformaticos12_5_cas.pdf 
(páxina 45 e seguintes)
