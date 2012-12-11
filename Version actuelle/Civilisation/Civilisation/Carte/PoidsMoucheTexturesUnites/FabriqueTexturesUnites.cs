using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Civilisation.PoidsMoucheTexturesCases
{
    class FabriqueTexturesUnites
    {
        // tableau de hash contenant les differents types de texture pour les terrains
		private Hashtable _tabTextureCaseUnite
		{
			get;
			set;
		}

        // permet d'obtenir la texture de la case d'un certain type de terrain
		public ImageBrush obtenirTextureUnite(int type)
		{
            ImageBrush retour;  // case que l'on va retourner

            // case non presente -> on l'ajoute
            if (!_tabTextureCaseUnite.ContainsKey(type))
            {                
                switch(type)  // selon le type de la case on rend la texture en conséquence
                {
                    case PConstantes.TypeUnite.ETUDIANT:
                        BitmapSource etudiant = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.etudiant.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
                        retour = new ImageBrush(etudiant);
                            break;
                    case PConstantes.TypeUnite.ENSEIGNANT:
                        BitmapSource enseignant = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.enseignant.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
                        retour = new ImageBrush(enseignant);
                            break;
                    case PConstantes.TypeUnite.DIRECTEUR:
                        BitmapSource directeur = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.directeur.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
                        retour = new ImageBrush(directeur);
                            break;
                    default:// Dans le cas d'erreur on ajoute un etudiant.
                        BitmapSource etudiant_err = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.etudiant.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
                        retour = new ImageBrush(etudiant_err);   
                        break;
                }
                // on l'insere dans le tableau pour pouvoir réutiliser la même instance de cette texture une nouvelle fois
                 _tabTextureCaseUnite.Add(type, retour);
            }
            else
            {
                // case presente -> on la retourne
                retour = (ImageBrush) _tabTextureCaseUnite[type];
            }

            return retour;
        }

      
        // constrcuteur de la fabrique
        public FabriqueTexturesUnites()
		{
            _tabTextureCaseUnite = new Hashtable();
        }
    }
}
