-- CREATE TABLE sides (
--     id int NOT NULL AUTO_INCREMENT,
--     name VARCHAR (255) NOT NULL,
--     description VARCHAR (255) NOT NULL,
--     price DECIMAL(10, 2) NOT NULL,
--     PRIMARY KEY (id)
-- );

-- INSERT INTO sides (name, description, price) VALUES ("Fries", "1 full pound!", 9.99);

-- SELECT * FROM smoothies;

-- ALTER TABLE smoothies MODIFY COLUMN price DECIMAL(10,2);

-- UPDATE smoothies SET price = 7.99, description = "Plain Jane with Cheese" WHERE id = 1; 

-- DELETE FROM smoothies WHERE id = 1;

-- User TABLE CREATION
CREATE TABLE users (
id VARCHAR(255) NOT NULL,
username VARCHAR(20) NOT NULL,
email VARCHAR(50) NOT NULL,
hash VARCHAR(255) NOT NULL,
PRIMARY KEY(id),
UNIQUE KEY email (email)
);

--FAVORITES TABLE

CREATE TABLE userburgers(
    id int NOT NULL_AUTOINCREMENT,
    burgerId in NOT NULL,
    userId VARCHAR(255) NOT NULL,

    PRIMARY KEY (id),
    INDEX (userId),

    FOREIGN KEY (userId)
    REFERENCES users(id)
    ON DELETE CASCADE, 

    FOREIGN KEY (burgerId)
    REFERENCES burgers(id)
    ON DELETE CASCADE
)


