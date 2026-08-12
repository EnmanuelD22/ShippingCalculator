# 📦 ShippingCalculator - Cotizador Internacional

**ShippingCalculator** es una solución de software empresarial diseñada para automatizar y optimizar el proceso de cálculo de tarifas para envíos internacionales. El sistema garantiza precisión, escalabilidad y una experiencia de usuario moderna, aplicando reglas de negocio estrictas mediante un diseño de software estructurado y desacoplado.

---

## ✨ Características Principales

*   **Cálculo en Tiempo Real:** Determinación inmediata de costos basados en el peso del paquete y las tasas configuradas por destino.
*   **Patrón Strategy:** Implementación de estrategias de cálculo flexibles que permiten aplicar diferentes reglas de negocio según el país sin modificar el núcleo del sistema.
*   **Validaciones Defensivas:** Uso de *Guard Clauses* para asegurar la integridad de los datos antes de cualquier procesamiento.
*   **Arquitectura Robusta:** Estructura monolítica en capas que garantiza un flujo de información ordenado y fácil de mantener.
*   **Interfaz de Usuario Premium:** Diseño moderno y responsivo mejorado con *Tom Select* para una experiencia de usuario fluida y profesional.
*   **Manejo de Excepciones:** Gestión centralizada de errores para una retroalimentación clara y segura al usuario final.

---

## 🏛️ Arquitectura del Sistema

El proyecto sigue una **Arquitectura Monolítica en Capas (N-Tier)**, donde cada componente tiene una responsabilidad específica, facilitando el mantenimiento y la escalabilidad.

## 💻 Stack Tecnológico

El desarrollo de ShippingCalculator se fundamenta en un ecosistema de Microsoft robusto y escalable:

### Backend & Lógica Core
* **Lenguaje:** C#
* **Framework:** .NET (ASP.NET Core MVC)
* **Arquitectura:** Monolítica por capas

### Persistencia de Datos
* **ORM:** Entity Framework Core
* **Base de Datos:** Microsoft SQL Server

### Frontend
* **UI Framework:** Bootstrap 5
* **Componente Interactivo:** Tom Select (para selectores de búsqueda avanzada)
* **Estilos:** CSS3 con diseño personalizado (UI/UX moderno)
