CREATE TABLE IF NOT EXISTS accounts(
  id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  name varchar(255) COMMENT 'User Name',
  email varchar(255) COMMENT 'User Email',
  picture varchar(255) COMMENT 'User Picture'
) default charset utf8;

CREATE TABLE IF NOT EXISTS recipes(
  id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
  picture VARCHAR(255) NOT NULL,
  title VARCHAR(255) NOT NULL,
  subTitle VARCHAR(255),
  category VARCHAR(255),
  creatorId VARCHAR(255) NOT NULL,
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',

  FOREIGN KEY (creatorId) 
    REFERENCES accounts(id) 
    ON DELETE CASCADE

)default charset utf8;

CREATE TABLE IF NOT EXISTS ingredients(
  id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
  name VARCHAR(255) NOT NULL,
  quantity VARCHAR(255) NOT NULL,
  recipeId INT NOT NULL,
  creatorId VARCHAR(255) NOT NULL,
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',

  FOREIGN KEY (creatorId)
    REFERENCES accounts(id)
    ON DELETE CASCADE,

  FOREIGN KEY (recipeId)
    REFERENCES recipes(id)
    ON DELETE CASCADE

) default charset utf8;

CREATE TABLE IF NOT EXISTS steps(
  id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
  position INT,
  body TEXT NOT NULL,
  recipeId INT NOT NULL,
  creatorId VARCHAR(255) NOT NULL,
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  FOREIGN KEY (creatorId)
    REFERENCES accounts(id)
    ON DELETE CASCADE,

  FOREIGN KEY (recipeId)
    REFERENCES recipes(id)
    ON DELETE CASCADE

) default charset utf8;

CREATE TABLE IF NOT EXISTS favorites(
  id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
  recipeId INT NOT NULL,
  accountId VARCHAR(255) NOT NULL,

  FOREIGN KEY (recipeId)
    REFERENCES recipes(id)
    ON DELETE CASCADE,

  FOREIGN KEY (accountId)
    REFERENCES accounts(id)
    ON DELETE CASCADE

) default charset utf8;

--Practice Area

-- Post Recipe
-- INSERT INTO recipes (picture, title, subTitle, category, creatorId)
-- VALUES ('https://media.istockphoto.com/photos/breakfast-burrito-picture-id1218426641?k=20&m=1218426641&s=612x612&w=0&h=GtyYkLBmWi3b_e97341Hxmf2oSPRI2Ui0idw14S_dZk=', 'Burrito', 'Breakfast Burrito', 'Breakfast', '627582ed8300624c500e3d8a');
-- SELECT LAST_INSERT_ID();

-- Get All Recipes
-- SELECT r.*, a.* FROM recipes r JOIN accounts a ON r.creatorId = a.id;

--Get Recipe by Id
-- SELECT r.*, a.* FROM recipes r JOIN accounts a ON r.creatorId = a.id WHERE r.id = @id;

--Put Recipe
-- UPDATE recipes SET category = @Category, picture = @Picture, subTitle = @SubTitle, title = @Title WHERE id = @Id;

--Delete Recipe
-- DELETE FROM recipes WHERE id = @id LIMIT 1;

--Post Favorite
-- INSERT INTO favorites (recipeId, accountId) VALUES (3, "627582ed8300624c500e3d8a"); SELECT LAST_INSERT_ID();

--Get Ingredient For Recipe
  -- SELECT a.*, i.* FROM ingredients i JOIN accounts a ON i.creatorId = a.id WHERE i.recipeId = @id;

--Get Ingredient by Id
-- SELECT i.*, a.* FROM ingredients i JOIN accounts a ON i.creatorId = a.id WHERE i.id = @id;

--Post Ingredient
-- INSERT INTO ingredients (name, quantity, creatorId, recipeId) VALUES ("Eggs", "3", "627582ed8300624c500e3d8a", 3); SELECT LAST_INSERT_ID();

--Put Ingredient
-- UPDATE ingredients SET name = @Name, quantity = @Quantity WHERE id = @Id;

--Delete Ingredient
-- DELETE FROM ingredients WHERE id = @id LIMIT 1;

--Get Favorite By Id
-- SELECT f.*, a.* FROM favorites f JOIN accounts a ON f.accountId = a.id WHERE f.id = 4;

--Get Favorite by Account
SELECT a.*, r.*, f.* FROM favorites f JOIN recipes r ON f.recipeId = r.id JOIN accounts a ON r.creatorId = a.id WHERE f.accountId = "627582ed8300624c500e3d8a";

SELECT f.*, a.id AS creatorId FROM favorites f JOIN accounts a ON f.accountId = a.id WHERE f.accountId = "627582ed8300624c500e3d8a";
