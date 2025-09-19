# RPG-bike

## Présentation

RPG-bike est un jeu de rôle textuel (console) en C# où le joueur incarne un cycliste qui doit participer à différentes courses en choisissant son vélo, en achetant des accessoires et consommables, et en gérant son inventaire pour optimiser ses performances.  

Le jeu simule des courses sur différents types de terrains, avec des événements aléatoires et des interactions pendant la course.

---

## Fonctionnalités principales

### 1. Choix du vélo

- Trois types de vélos accessibles, chacun avec des caractéristiques propres :
  - **Vélo de Route** (rapide sur asphalte)
  - **Vélo Gravel** (polyvalent, performant sur gravier)
  - **VTT** (résistant sur sentiers difficiles)

- Chaque vélo a des stats :  
  - **Vitesse** (km/h moyenne)  
  - **Confort** (impacte sur la vitesse effective)  
  - **Résistance** (pas encore exploitée, future évolution)  
- Chaque vélo a un coût en crédits qu’il faut dépenser pour l’acheter.

### 2. Accessoires et Inventaire

- **Accessoires améliorations** (liés et équipés sur un vélo spécifique) :  
  - *Pneu tubeless* : réduit de 80% le risque de crevaison  
  - *Selle gel* : augmente le confort (+2), ce qui augmente la vitesse effective  
  - *Frein à disque* : permet de ne pas perdre de vitesse sous la pluie  
  - *Casque aérodynamique* : réduit les conséquences des accidents en peloton  
  - *Formation peloton* : offre un boost de vitesse lié au nombre de coéquipiers, avec risque d’accident

- **Consommables** (stockés dans l’inventaire global du joueur, consommables à volonté) :  
  - *Collation* : booste la vitesse de 4 km/h pendant 10 minutes après consommation  
- Chaque accessoire/consommable a un coût en crédits à acheter dans la boutique.

### 3. Boutique

- Le joueur peut acheter vélos, accessoires/ameliorations (à appliquer à un vélo sélectionné), et consommables (stockés dans l’inventaire).
- Les achats sont déduits du crédit du joueur.
- Le joueur doit choisir un vélo avant de pouvoir acheter des améliorations pour celui-ci.

### 4. Simulation des courses

- Courses disponibles sur plusieurs terrains différents :  
  - Asphalte  
  - Gravier  
  - Sentier

- Le temps de la course est calculé en fonction de la vitesse et du confort du vélo, ajusté selon le terrain.
- La météo pluie peut impacter les performances, sauf si le vélo a un frein à disque.
- Événements aléatoires pendant la course :  
  - **Crevaison**, avec possibilité de payer pour une réparation rapide ou subir une perte de vitesse.  
  - **Collation** donnée par les supporters, boostant la vitesse temporairement.  
  - **Formation peloton** : le joueur peut choisir d’en bénéficier, avec un boost de vitesse mais un risque d’accident.
- Le joueur est invité à prendre des décisions interactives pendant la course (ex : utiliser une collation, dépenser des crédits pour réparer).

### 5. Gestion du crédit

- Le joueur commence avec un crédit initial.
- Gagne des crédits en terminant les courses selon la distance et bonus éventuels.
- Dépense des crédits pour acheter vélos, accessoires, consommables et payer réparations.

---

## Choix des vélos

| Vélo         | Vitesse | Confort | Résistance | Coût (crédits) |
|--------------|---------|---------|------------|----------------|
| Vélo Route   | 10      | 5       | 6          | 15             |
| Vélo Gravel  | 8       | 8       | 7          | 12             |
| VTT          | 7       | 9       | 10         | 10             |

---

## Accessoires et Effets

| Accessoire          | Type         | Coût | Effet principal                                    |
|---------------------|--------------|------|---------------------------------------------------|
| Pneu tubeless       | Amélioration | 10   | Réduit de 80% le risque de crevaison              |
| Selle gel           | Amélioration | 5    | Augmente le confort (+2)                           |
| Frein à disque      | Amélioration | 5    | Permet de rouler à pleine vitesse sous la pluie  |
| Casque aérodynamique| Amélioration | 6    | Réduit l’impact des accidents en peloton          |
| Formation peloton   | Amélioration | 8    | Boost de vitesse en peloton avec risque d’accident|
| Collation           | Consommable  | 2    | Boost de vitesse +4 km/h pendant 10 minutes       |

---

## Types de terrains des courses

| Terrain   | Impact sur vélo gravels       | Impact sur Vélos Route    | Impact sur VTT              |
|-----------|-------------------------------|--------------------------|----------------------------|
| Asphalte  | -2 km/h vitesse               | Pas d’impact              | -2 km/h vitesse            |
| Gravier   | Pas d’impact                  | -3 km/h vitesse           | Pas d’impact               |
| Sentier   | -4 km/h vitesse              | -4 km/h vitesse           | Pas d’impact               |

---

## Interactions en jeu

- Pendant une course, le joueur est interrogé pour :  
  - Utiliser une collation (si disponible en stock)  
  - Dépenser des crédits pour réparer une crevaison  
  - Décider d’utiliser la formation peloton (avec risque d’accident et boost vitesse)  

- Ces interactions influencent directement la performance et le temps final.

---

## Évolutions possibles

- Ajout de nouveaux types de vélos ou accessoires  
- Système de niveaux et compétences  
- Gestion durable des ressources (usure des accessoires, nombre limité d’usages)  
- Sauvegarde et chargement de la progression  
- Ajout de conditions météo variées

---

## Installation et utilisation

1. Cloner le dépôt  
2. Ouvrir dans un IDE compatible C# (.NET 9)  
3. Lancer avec `dotnet run` dans le dossier du projet  
4. Suivre les instructions du menu dans la console
