/*
Modèle de script de post-déploiement							
--------------------------------------------------------------------------------------
 Ce fichier contient des instructions SQL qui seront ajoutées au script de compilation.		
 Utilisez la syntaxe SQLCMD pour inclure un fichier dans le script de post-déploiement.			
 Exemple :      :r .\monfichier.sql								
 Utilisez la syntaxe SQLCMD pour référencer une variable dans le script de post-déploiement.		
 Exemple :      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

INSERT INTO Categories (CT_Name, CT_Description) VALUES ('Les Infectés', 'Ce sont des être humains qui ont subis des mutations dû à la magie noire, leur seul but est de dévorer les non infectés durant la nuit tombé')
INSERT INTO Categories (CT_Name, CT_Description) VALUES ('Les Normis', 'Ce sont des être humains tout ce qui a de plus ordinaire')
--INSERT INTO Categories (CT_Name, CT_Description) VALUES ('Les Spéciaux', 'Ce sont des être humains qui ont acquis une capacité particulière, qui leur parmet de combattre les infecté')

INSERT INTO Roles(Role_Name, [Description],CategorieID) VALUES ('Wendigo', 'Le Wendigo est une créature squelettique à l''appétit insatiable, en somme, plus il se nourrit, plus il a faim. Autrefois un être doué de raison, il n''est plus que l''ombre de lui même. Victime d''une puissante magie noir qui, pour l''asservire, il se réveil la nuit pour commettre ses sombres mefaits',1)
INSERT INTO Roles(Role_Name, [Description],CategorieID) VALUES ('L''Invité', 'L''invité est un humains lamda, un normi en quelque sorte. Son rôle au sein du jeu n''en reste pas moins important car il doit rester attentif au dire des autres joueurs pour démasquer les Wendigowak',2)
