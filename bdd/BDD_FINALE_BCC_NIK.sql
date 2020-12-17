-- phpMyAdmin SQL Dump
-- version 5.0.3
-- https://www.phpmyadmin.net/
--
-- Hôte : 127.0.0.1
-- Généré le : jeu. 17 déc. 2020 à 00:19
-- Version du serveur :  10.4.14-MariaDB
-- Version de PHP : 7.4.11

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de données : `bcc`
--

-- --------------------------------------------------------

--
-- Structure de la table `produit`
--

CREATE TABLE `produit` (
  `id_produit` int(11) NOT NULL,
  `id_lot` int(11) NOT NULL,
  `prix_depart` float NOT NULL,
  `description` varchar(150) DEFAULT NULL,
  `date_vente` varchar(50) DEFAULT NULL,
  `estimation` float DEFAULT NULL,
  `is_vendu` tinyint(4) NOT NULL,
  `prix_reserve` float DEFAULT NULL,
  `region` varchar(50) NOT NULL,
  `attribut` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `produit`
--

INSERT INTO `produit` (`id_produit`, `id_lot`, `prix_depart`, `description`, `date_vente`, `estimation`, `is_vendu`, `prix_reserve`, `region`, `attribut`) VALUES
(1, 1, 0, 'sdsdsdd', '', 0, 0, 0, '', '');

--
-- Index pour les tables déchargées
--

--
-- Index pour la table `produit`
--
ALTER TABLE `produit`
  ADD PRIMARY KEY (`id_produit`),
  ADD KEY `id_lot` (`id_lot`);

--
-- AUTO_INCREMENT pour les tables déchargées
--

--
-- AUTO_INCREMENT pour la table `produit`
--
ALTER TABLE `produit`
  MODIFY `id_produit` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- Contraintes pour les tables déchargées
--

--
-- Contraintes pour la table `produit`
--
ALTER TABLE `produit`
  ADD CONSTRAINT `produit_ibfk_1` FOREIGN KEY (`id_lot`) REFERENCES `lot` (`id_lot`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
