# CollectEats
## Architecture

```jsx
/MyApp.API
|-- Controllers/             (Contrôleurs pour gérer les requêtes HTTP)
|   |-- UtilisateurController.cs
|   |-- RestaurantController.cs
|   |-- ...
|-- Models/                 (Modèles représentant les tables de votre base de données)
|   |-- Utilisateur.cs
|   |-- Restaurant.cs
|   |-- ...
|-- DTOs/                   (Objets de transfert de données pour la communication avec le frontend)
|   |-- UtilisateurDTO.cs
|   |-- RestaurantDTO.cs
|   |-- ...
|-- Data/
|   |-- ApplicationDbContext.cs   (Contexte de base de données pour EF Core)
|-- Repositories/           (Couche d'accès aux données)
|   |-- UtilisateurRepository.cs
|   |-- RestaurantRepository.cs
|   |-- ...
|-- Services/               (Services contenant la logique métier)
|   |-- UtilisateurService.cs
|   |-- RestaurantService.cs
|   |-- ...
|-- Migrations/             (Migrations de base de données pour EF Core)
|-- Infrastructure/         (Configuration, Initialisation, Services Tiers...)
|-- wwwroot/                (Ressources statiques, si nécessaire)
|-- Startup.cs              (Configuration de l'application)
|-- ...
```

## Explication de l’architecture

### Couche `API`

Elle regroupe l’ensemble des controleurs et intègre l’automapper.

Elle gère l’identity de l’utilisateur connecté à l’aide des nouveaux endpointsApi (AddIdentityApiEndpoints) introduit en .net 8. 

### Couche `Core`

Implémente le service CRUD générique qui s’occupe d’interroger le repository en passant l’objet transformé (en faisant le MAP entre DTO→MODELS).

La logique des fonctions se retrouvera donc dans cette couche.

### Couche `Data`

Permet l’accès à la BDD on y retrouvera donc l’ensemble des requêtes.

### Couche `DTOs`

L’ensemble des DTOs pour les modèles seront présent et organisé dans cette couche.

### Couche `Shared`

Cette couche pourra permettre l’utilisation d’un fonction dans l’ensemble de la solution.

### CodeGen HTTPClient

Création des services et modèles avec **`ng-openapi-gen`**

Licence : **MIT**

Bien pensé à sauvegarder en local le fichier swagger.json !

```sql
curl https://localhost:7110/swagger/v1/swagger.json -o swagger.json
```

**Commande de génération :**

```rust
npx ng-openapi-gen
```

Start ng serve with proxy conf

```tsx
--proxy-config proxy.conf.json
```
## Objectif

Permettre par exemple à un camion de pizza ou à un restaurant d’augmenter ses ventes sans pour autant augmenter ses couverts. 

L’application lui permettrai de mettre en avant ses produits sans avoir à se créer un site web.
De plus ça éviterai de devoir gérer les appels pour prendre commande...
