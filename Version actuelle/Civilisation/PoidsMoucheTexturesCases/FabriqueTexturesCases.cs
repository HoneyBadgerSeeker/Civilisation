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
    class FabriqueTexturesCases
    {
        // tableau de hash contenant les differents types de texture pour les terrains
		private Hashtable _tabTextureCaseTerrain
		{
			get;
			set;
		}
        // tableau de hash contenant les differents types de ressources pour les terrains
		private Hashtable _tabTextureCaseRessource
		{
			get;
			set;
		}

        // permet d'obtenir la texture de la case d'un certain type de terrain
		public ImageBrush obtenirTextureCaseTerrain(int type)
		{
            ImageBrush retour;  // case que l'on va retourner

            // case non presente -> on l'ajoute
            if (!_tabTextureCaseTerrain.ContainsKey(type))
            {                
                switch(type)  // selon le type de la case on rend la texture en conséquence
                {
                    case PConstantes.TypeCase.DESERT:
                    case PConstantes.TypeCase.DESERT_FER:
                    case PConstantes.TypeCase.DESERT_NOURRITURE:
                        BitmapSource desert = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.desert.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
                        retour = new ImageBrush(desert);
                            break;

                    case PConstantes.TypeCase.MONTAGNE:
                    case PConstantes.TypeCase.MONTAGNE_FER:
                    case PConstantes.TypeCase.MONTAGNE_NOURRITURE:
                        BitmapSource montagne = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.montagne.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
                        retour = new ImageBrush(montagne);
                            break;

                    case PConstantes.TypeCase.PLAINE:
                    case PConstantes.TypeCase.PLAINE_FER:
                    case PConstantes.TypeCase.PLAINE_NOURRITURE:
                    default:// Dans le cas d'erreur on ajoute une plaine.
                        BitmapSource plaine = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.plaine.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
                        retour = new ImageBrush(plaine);   
                        break;
                }
                // on l'insere dans le tableau pour pouvoir réutiliser la même instance de cette texture une nouvelle fois
                 _tabTextureCaseTerrain.Add(type, retour);
            }
            else
            {
                // case presente -> on la retourne
                retour = (ImageBrush) _tabTextureCaseTerrain[type];
            }

            return retour;
        }

        // permet d'obtenir la texture de la case d'un certain type de ressource
        public ImageBrush obtenirTextureCaseRessource(int type)
        {
            ImageBrush retour;  // case que l'on va retourner

            // case non presente -> on l'ajoute
            if (!_tabTextureCaseRessource.ContainsKey(type))
            {
                switch (type)  // selon le type de la case on rend la texture en conséquence
                {
                    case PConstantes.TypeCase.DESERT_FER:
                    case PConstantes.TypeCase.MONTAGNE_FER:
                    case PConstantes.TypeCase.PLAINE_FER:
                        BitmapSource fer = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.fer.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
                        retour = new ImageBrush(fer);
                        break;
                    case PConstantes.TypeCase.DESERT_NOURRITURE:
                    case PConstantes.TypeCase.MONTAGNE_NOURRITURE:
                    case PConstantes.TypeCase.PLAINE_NOURRITURE:
                        BitmapSource fruit = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.fruit.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
                        retour = new ImageBrush(fruit);
                        break;

                    default:// Dans le cas d'erreur on ajoute du fer.
                        BitmapSource ferB = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.fer.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
                        retour = new ImageBrush(ferB);
                        break;
                }
                // on l'insere dans le tableau pour pouvoir réutiliser la même instance de cette texture une nouvelle fois
                _tabTextureCaseRessource.Add(type, retour);
            }
            else
            {
                // case presente -> on la retourne
                retour = (ImageBrush)_tabTextureCaseRessource[type];
            }

            return retour;
        }

        // constrcuteur de la fabrique
        public FabriqueTexturesCases()
		{
            _tabTextureCaseTerrain = new Hashtable();
            _tabTextureCaseRessource = new Hashtable();	
        }
    }
}
