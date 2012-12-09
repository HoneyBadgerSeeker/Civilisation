﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil
//     Les modifications apportées à ce fichier seront perdues si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------
namespace PInterfaces_Fabrique_Abstraite
{
    using PConstantes;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using PCase;
    using PJoueur;

    public abstract class Unite : IEquatable<Unite>
    {
        // nom de l'unite
        public string _nomUnite
        {
            get;
            set;
        }

        // capacite d'attaque
        public int _attaque
        {
            get;
            set;
        }

        // capacite de defense
        public int _defense
        {
            get;
            set;
        }

        // capacite de vie
        public int _vie
        {
            get;
            set;
        }

        // capacite de mouvement
        public int _mouvement
        {
            get;
            set;
        }

        // postion x de l'unite
        public int _posx_unite
        {
            get;
            set;
        }

        // position y de l'unite
        public int _posy_unite
        {
            get;
            set;
        }

        // deplacement de l'unite
        public virtual void deplacer(Direction dir)
        {
            // si deplacement possible
            if (_mouvement >= 1)
            {
                // **********************************************//
                // ajouter traitement associe ICI !!!!!
                // **********************************************//
                retirerPointDeplacement();
            }
        }

        // cout de l'unite
        public abstract int getCout();

        // constructeur de l'unite
        public Unite(int x, int y)
        {
            _posx_unite = x;
            _posy_unite = y;
        }

        // enlever un point de deplacement
        public virtual void retirerPointDeplacement()
        {
            _mouvement--;
        }

        // methode pour comparer deux unites
        public bool Equals(Unite other)
        {
            /* return ((_nomUnite == other._nomUnite) && (_attaque == other._attaque) && (_defense == other._defense) && (_mouvement == other._mouvement) && (_vie == other._vie)
                  && (_case == other._case));*/
            return false;
        }
    }
}

