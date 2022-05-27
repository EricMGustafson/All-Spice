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
updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update'
)default charset utf8;







INSERT INTO recipes (picture, title, subTitle, category, creatorId)
VALUES ('https://thiscatdoesnotexist.com', 'Purina', 'Good kitty', 'breakfast', '627582ed8300624c500e3d8a');
SELECT LAST_INSERT_ID();