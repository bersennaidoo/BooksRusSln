-- MySQL Script generated by MySQL Workbench
-- Sat 24 Feb 2024 15:38:05
-- Model: New Model    Version: 1.0
-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema BooksRus
-- -----------------------------------------------------
DROP SCHEMA IF EXISTS `BooksRus` ;

-- -----------------------------------------------------
-- Schema BooksRus
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `BooksRus` ;
USE `BooksRus` ;

-- -----------------------------------------------------
-- Table `BooksRus`.`Author`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `BooksRus`.`Author` ;

CREATE TABLE IF NOT EXISTS `BooksRus`.`Author` (
  `AuthorId` INT NOT NULL AUTO_INCREMENT,
  `FirstName` VARCHAR(45) NOT NULL,
  `LastName` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`AuthorId`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `BooksRus`.`Genre`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `BooksRus`.`Genre` ;

CREATE TABLE IF NOT EXISTS `BooksRus`.`Genre` (
  `GenreId` VARCHAR(45) NOT NULL,
  `Name` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`GenreId`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `BooksRus`.`Book`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `BooksRus`.`Book` ;

CREATE TABLE IF NOT EXISTS `BooksRus`.`Book` (
  `BookId` INT NOT NULL AUTO_INCREMENT,
  `Title` VARCHAR(45) NOT NULL,
  `Price` DECIMAL(18,2) NOT NULL,
  `GenreId` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`BookId`),
  INDEX `fk_Book_1_idx` (`GenreId` ASC) VISIBLE,
  CONSTRAINT `fk_Book_1`
    FOREIGN KEY (`GenreId`)
    REFERENCES `BooksRus`.`Genre` (`GenreId`)
    ON DELETE CASCADE
    ON UPDATE CASCADE)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `BooksRus`.`AuthorBook`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `BooksRus`.`AuthorBook` ;

CREATE TABLE IF NOT EXISTS `BooksRus`.`AuthorBook` (
  `BookId` INT NOT NULL,
  `AuthorId` INT NOT NULL,
  PRIMARY KEY (`BookId`, `AuthorId`),
  INDEX `fk_AuthorBook_1_idx` (`AuthorId` ASC) VISIBLE,
  CONSTRAINT `fk_AuthorBook_1`
    FOREIGN KEY (`AuthorId`)
    REFERENCES `BooksRus`.`Author` (`AuthorId`)
    ON DELETE CASCADE
    ON UPDATE CASCADE,
  CONSTRAINT `fk_AuthorBook_2`
    FOREIGN KEY (`BookId`)
    REFERENCES `BooksRus`.`Book` (`BookId`)
    ON DELETE CASCADE
    ON UPDATE CASCADE)
ENGINE = InnoDB;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;