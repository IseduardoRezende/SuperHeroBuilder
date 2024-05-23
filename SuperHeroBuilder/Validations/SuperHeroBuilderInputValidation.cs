namespace SuperHeroBuilder.Validations
{
    public static class SuperHeroBuilderInputValidation
    {
        public static void ValidateInput<T>(T value, string paramName)
        {
            if (value is null)
                throw new Exception($"Input value is null in {paramName}");
        }

        public static void ValidateInputs<T>(T[] values, string paramName)
        {
            if (values is null)
                throw new Exception($"Input values are null in {paramName}");
        }
    }
}
