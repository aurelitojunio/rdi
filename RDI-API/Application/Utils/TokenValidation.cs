
namespace Application.Utils
{
    public class TokenValidation
    {
        const int LAST_PART_OF_CARD_TO_TOKEN = 4;
        const int TOKEN_EXPIRATION_TIME = 30;

        public static long CreateToken(long cardNo, int cvv)
        {
            string strCardNo = Convert.ToString(cardNo);
            string lastPartOfCard = strCardNo.Substring(strCardNo.Length - LAST_PART_OF_CARD_TO_TOKEN, LAST_PART_OF_CARD_TO_TOKEN);
            int[] array = lastPartOfCard.Select(x => (int)char.GetNumericValue(x)).ToArray();
            
            var shiftRight = ShiftRight(array, cvv).ToArray();
            
            return Convert.ToInt32(string.Concat(shiftRight));
        }

        public static bool IsTokenCreationDateValid(DateTime creationDate)
        {
            return (DateTime.Now - creationDate).Minutes <= TOKEN_EXPIRATION_TIME;
        }

        public static int MathMod(int a, int b)
        {
            int c = ((a % b) + b) % b;
            return c;
        }

        public static IEnumerable<T> ShiftRight<T>(IList<T> values, int shift)
        {
            for (int index = 0; index < values.Count; index++)
            {
                yield return values[MathMod(index - shift, values.Count)];
            }
        }
    }
}
