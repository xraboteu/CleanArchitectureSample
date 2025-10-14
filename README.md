# .NET Clean Architecture Sample (Modular Monolith)

Ce dépôt démontre une structure **Modular Monolith** en .NET avec **Minimal APIs** + **MediatR**.
Il illustre l'article "Vertical Slice & Modular Monolith : le sweet spot".

## Modules
- Billing (facturation)
- Catalog (catalogue produits)

## Démarrage rapide
```bash
# Requis: .NET 9 SDK
dotnet --info

# Restaurer et builder
dotnet restore
dotnet build

# Lancer l'host
dotnet run --project src/Host/Host.csproj
```
API exposée par défaut sur http://localhost:5187

## Points clés
- Un exécutable unique (monolithe), modules chargés comme "plugins"
- Couche Domain / Application par module
- Endpoints Minimal APIs par feature (vertical slice légère)
- MediatR pour orchestrer les cas d'usage
