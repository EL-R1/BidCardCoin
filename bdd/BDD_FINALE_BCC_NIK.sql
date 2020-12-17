-- phpMyAdmin SQL Dump
-- version 5.0.3
-- https://www.phpmyadmin.net/
--
-- Hôte : 127.0.0.1
-- Généré le : mer. 16 déc. 2020 à 19:17
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
-- Base de données : `mydb`
--

-- --------------------------------------------------------

--
-- Structure de la table `achat`
--

CREATE TABLE `achat` (
  `id_acheteur` int(11) NOT NULL,
  `id_produit` int(11) NOT NULL,
  `prix` float DEFAULT NULL,
  `is_live` tinyint(4) DEFAULT NULL,
  `is_telephone` tinyint(4) DEFAULT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Structure de la table `acheteur`
--

CREATE TABLE `acheteur` (
  `id_acheteur` int(11) NOT NULL,
  `id_personne` int(11) NOT NULL,
  `is_solvable` tinyint(4) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `acheteur`
--

INSERT INTO `acheteur` (`id_acheteur`, `id_personne`, `is_solvable`) VALUES
(1, 3, 1),
(2, 5, 0),
(3, 1, 0),
(4, 1, 0);

-- --------------------------------------------------------

--
-- Structure de la table `categorie`
--

CREATE TABLE `categorie` (
  `id_categorie` int(11) NOT NULL,
  `nom` varchar(45) DEFAULT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `categorie`
--

INSERT INTO `categorie` (`id_categorie`, `nom`) VALUES
(1, 'coucou'),
(2, 'sdqfqzesf asqd');

-- --------------------------------------------------------

--
-- Structure de la table `categorie_produit`
--

CREATE TABLE `categorie_produit` (
  `id_produit` int(11) NOT NULL,
  `id_categorie` int(11) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Structure de la table `comissaire_priseur`
--

CREATE TABLE `comissaire_priseur` (
  `id_comissaire_priseur` int(11) NOT NULL,
  `id_produit` int(11) NOT NULL,
  `id_personne` int(11) NOT NULL,
  `comissaire_priseurcol` int(11) DEFAULT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Structure de la table `estimation`
--

CREATE TABLE `estimation` (
  `id_comissaire_priseur` int(11) NOT NULL,
  `id_vendeur` int(11) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Structure de la table `lieu`
--

CREATE TABLE `lieu` (
  `id_lieu` int(11) NOT NULL,
  `nom` varchar(50) NOT NULL,
  `adresse` varchar(150) NOT NULL,
  `ville` varchar(45) NOT NULL,
  `code_postal` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `lieu`
--

INSERT INTO `lieu` (`id_lieu`, `nom`, `adresse`, `ville`, `code_postal`) VALUES
(1, 'Nantes', 'Nantes', 'Nantes', 44000),
(2, 'COUCOU', 'dddd', 'SALUT', 95000);

-- --------------------------------------------------------

--
-- Structure de la table `lot`
--

CREATE TABLE `lot` (
  `id_lot` int(11) NOT NULL,
  `id_vente_enchere` int(11) NOT NULL,
  `description` varchar(150) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `lot`
--

INSERT INTO `lot` (`id_lot`, `id_vente_enchere`, `description`) VALUES
(1, 2, 'Description');

-- --------------------------------------------------------

--
-- Structure de la table `ordre_achat`
--

CREATE TABLE `ordre_achat` (
  `id_ordre_achat` int(11) NOT NULL,
  `id_produit` int(11) NOT NULL,
  `id_acheteur` int(11) NOT NULL,
  `montant` float DEFAULT NULL,
  `date_achat` varchar(50) DEFAULT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Structure de la table `personne`
--

CREATE TABLE `personne` (
  `id_personne` int(11) NOT NULL,
  `username` varchar(20) DEFAULT NULL,
  `password` varchar(20) DEFAULT NULL,
  `nom` varchar(45) NOT NULL,
  `email` varchar(45) DEFAULT NULL,
  `age` int(11) DEFAULT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `personne`
--

INSERT INTO `personne` (`id_personne`, `username`, `password`, `nom`, `email`, `age`) VALUES
(1, 'red', '1234', 'Antoine', 'antoine@gmail.com', 15),
(3, 'blue', '4321', 'Blue', 'blue@gmail.com', 4),
(5, 'redou2', 'qsdqsdsqd', 'Red', 'test', 159);

-- --------------------------------------------------------

--
-- Structure de la table `photo`
--

CREATE TABLE `photo` (
  `id_photo` int(11) NOT NULL,
  `id_produit` int(11) DEFAULT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

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
(1, 1, 50, 'COUCOU', '19/12/2020', 122, 0, 42, 'FFF', 'what ?');

-- --------------------------------------------------------

--
-- Structure de la table `vendeur`
--

CREATE TABLE `vendeur` (
  `id_vendeur` int(11) NOT NULL,
  `id_personne` int(11) NOT NULL,
  `id_produit` int(11) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Structure de la table `vente_enchere`
--

CREATE TABLE `vente_enchere` (
  `id_vente_enchere` int(11) NOT NULL,
  `date_vente_enchere` varchar(50) DEFAULT NULL,
  `id_lieu` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `vente_enchere`
--

INSERT INTO `vente_enchere` (`id_vente_enchere`, `date_vente_enchere`, `id_lieu`) VALUES
(1, '', 1),
(2, '18/12/2020', 1);

--
-- Index pour les tables déchargées
--

--
-- Index pour la table `acheteur`
--
ALTER TABLE `acheteur`
  ADD PRIMARY KEY (`id_acheteur`);

--
-- Index pour la table `categorie`
--
ALTER TABLE `categorie`
  ADD PRIMARY KEY (`id_categorie`);

--
-- Index pour la table `comissaire_priseur`
--
ALTER TABLE `comissaire_priseur`
  ADD PRIMARY KEY (`id_comissaire_priseur`);

--
-- Index pour la table `lieu`
--
ALTER TABLE `lieu`
  ADD PRIMARY KEY (`id_lieu`);

--
-- Index pour la table `lot`
--
ALTER TABLE `lot`
  ADD PRIMARY KEY (`id_lot`),
  ADD UNIQUE KEY `id_vente_enchere_UNIQUE` (`id_vente_enchere`);

--
-- Index pour la table `ordre_achat`
--
ALTER TABLE `ordre_achat`
  ADD PRIMARY KEY (`id_ordre_achat`);

--
-- Index pour la table `personne`
--
ALTER TABLE `personne`
  ADD PRIMARY KEY (`id_personne`);

--
-- Index pour la table `photo`
--
ALTER TABLE `photo`
  ADD PRIMARY KEY (`id_photo`);

--
-- Index pour la table `produit`
--
ALTER TABLE `produit`
  ADD PRIMARY KEY (`id_produit`),
  ADD UNIQUE KEY `id_lot_UNIQUE` (`id_lot`);

--
-- Index pour la table `vendeur`
--
ALTER TABLE `vendeur`
  ADD PRIMARY KEY (`id_vendeur`);

--
-- Index pour la table `vente_enchere`
--
ALTER TABLE `vente_enchere`
  ADD PRIMARY KEY (`id_vente_enchere`),
  ADD KEY `id_lieu` (`id_lieu`);

--
-- AUTO_INCREMENT pour les tables déchargées
--

--
-- AUTO_INCREMENT pour la table `comissaire_priseur`
--
ALTER TABLE `comissaire_priseur`
  MODIFY `id_comissaire_priseur` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT pour la table `ordre_achat`
--
ALTER TABLE `ordre_achat`
  MODIFY `id_ordre_achat` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT pour la table `personne`
--
ALTER TABLE `personne`
  MODIFY `id_personne` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;

--
-- AUTO_INCREMENT pour la table `produit`
--
ALTER TABLE `produit`
  MODIFY `id_produit` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT pour la table `vendeur`
--
ALTER TABLE `vendeur`
  MODIFY `id_vendeur` int(11) NOT NULL AUTO_INCREMENT;

--
-- Contraintes pour les tables déchargées
--

--
-- Contraintes pour la table `lot`
--
ALTER TABLE `lot`
  ADD CONSTRAINT `lot_ibfk_1` FOREIGN KEY (`id_vente_enchere`) REFERENCES `vente_enchere` (`id_vente_enchere`);

--
-- Contraintes pour la table `produit`
--
ALTER TABLE `produit`
  ADD CONSTRAINT `produit_ibfk_1` FOREIGN KEY (`id_lot`) REFERENCES `lot` (`id_lot`);

--
-- Contraintes pour la table `vente_enchere`
--
ALTER TABLE `vente_enchere`
  ADD CONSTRAINT `vente_enchere_ibfk_1` FOREIGN KEY (`id_lieu`) REFERENCES `lieu` (`id_lieu`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;