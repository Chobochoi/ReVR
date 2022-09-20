// WARNING: Do not modify! Generated file.

namespace UnityEngine.Purchasing.Security {
    public class GooglePlayTangle
    {
        private static byte[] data = System.Convert.FromBase64String("nS+sj52gq6SHK+UrWqCsrKyora7yKeWaqLfKMsRP7g1M3lpCAAc1Ep9hKU2khtyeMpV3XoQo/6CcIsfAjmEUnTIDsl7E6QWO5PMDcAeOInbuDluISB286ZGsR3gYyTss2bKWov51TUkQqhSzWFCvCaqxjIkfvwldL6yirZ0vrKevL6ysrTKA+gkbKZMZAkDFxcy/aYOIMoq0M4ZlkgtuCNjtbRddavor6ARsrm6dE3btjqUv+mcn4SsuEcna4H5CaLu7eUTRHpqzV7s5WLZVmmMM4rSEBfgiyartCkD9N3XVj7KyHcTz+CYeBl1r8Lwd/Rh7gm64oEFx4qftFEbfPBzNWcWHEzEg2mejGdp9eGCrSp4mXoe/2U/VphvsBkDeLq+urK2s");
        private static int[] order = new int[] { 0,5,12,13,4,13,13,11,9,12,13,12,13,13,14 };
        private static int key = 173;

        public static readonly bool IsPopulated = true;

        public static byte[] Data() {
        	if (IsPopulated == false)
        		return null;
            return Obfuscator.DeObfuscate(data, order, key);
        }
    }
}
