﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil
//     Les modifications apportées à ce fichier seront perdues si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------
namespace PCivilisation
{
	using PInterfaces_Fabrique_Abstraite;
    using PJoueur;
    using PCarte;
    using PCase;
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;

	public class Ville
	{
        // nom de la ville
		public string _nomVille
		{
			get;
			set;
		}

        // nombre d'habitants que possede la ville
		public int _habitants
		{
			get;
			set;
		}

        // ressource en nourriture que possede la ville
		public int _ressourceNourriture
		{
			get;
			set;
		}

        // perimetre de la ville
		public int _perimetre
		{
			get;
			set;
		}

        // ressource en fer que possede la ville
		public int _ressourceFer
		{
			get;
			set;
		}

        // position y de la ville sur la carte (sur une case)
		public int _posy_ville
		{
			get;
			set;
		}

        // position x de la ville sur la carte (sur une case)
		public int _posx_ville
		{
			get;
			set;
		}

        // liste des unites presentes sur la ville
		public List<Unite> liste_unites
		{
			get;
			set;
		}

        // ressource necessaire en nouriture que possede la ville
        public int _ressourceNecessaireEnNourriture
        { 
            get; 
            set; 
        }

        // production en cours dans la ville
        public Unite _unite_en_prod
        {
            get;
            set;
        }
        
        // constructeur de Ville
		public Ville(int posx, int posy, string nomVille)
		{
            _posy_ville = posy;
            _posx_ville = posx;
            _habitants = 1;
            _unite_en_prod = null;
            liste_unites = new List<Unite>();
            _perimetre = 3; // Permettra de modifier la taille du perimetre de la ville
            _nomVille = nomVille; 
            _ressourceNourriture = 0; // L'increment du nombre de nourriture se fait au moment du clique du bouton fin tour
            _ressourceFer = 0; // L'increment du nombre de nourriture se fait au moment du clique du bouton fin tour
            _ressourceNecessaireEnNourriture = 10;
		}

        // ville achete un Enseignant
		public Unite acheterEnseignant()
		{
			throw new System.NotImplementedException();
		}

        // ville achete un Directeur
		public Unite acheterDirecteur()
		{
			throw new System.NotImplementedException();
		}

        // ville achete un Etudiant
		public Unite acheterEtudiant()
		{
			throw new System.NotImplementedException();
		}

        // ville agrandi son perimetre
		public void agrandirPerimetre()
		{
			throw new System.NotImplementedException();
		}

        // ville conquise d'un joueur
		public void conquise(Joueur joueurEnnemi)
		{
			throw new System.NotImplementedException();
		}

        // MAJ des ressources de la ville
        public void mettre_a_jour_ressources()
        {
            produireFer();
            produireNourriture();
            produireHabitants();
        }

        // calcul des ressources necessaire en nourriture pour la ville
        public void calculRessourceNecessaireNourriture()
        {
            _ressourceNecessaireEnNourriture = _ressourceNecessaireEnNourriture + ( _ressourceNecessaireEnNourriture / 2 );
        }

        // augmentation du nombre d'habitants
        public void produireHabitants()
        {
            if (_ressourceNourriture >= _ressourceNecessaireEnNourriture)
            {
                _habitants++;
                _ressourceNourriture -= _ressourceNecessaireEnNourriture;
                calculRessourceNecessaireNourriture();
            }
        }

        // production de fer
		public void produireFer()
		{
			throw new System.NotImplementedException();
		}

        // production de nourriture
		public void produireNourriture()
		{
            throw new System.NotImplementedException();
        }
    }
}

