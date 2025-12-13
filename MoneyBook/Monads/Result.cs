namespace MoneyBook.Monads
{
    public readonly struct Result<T, TError>
    {
        private readonly T? _value;
        private readonly TError? _error;

        public bool IsSuccess { get; }
        public bool IsFailure => !IsSuccess;

        public T Value =>
            IsSuccess
                ? _value!
                : throw new InvalidOperationException("Result does not contain a success value.");

        public TError Error =>
            IsFailure
                ? _error!
                : throw new InvalidOperationException("Result does not contain an error.");

        private Result(T successValue)
        {
            IsSuccess = true;
            _value = successValue;
            _error = default;
        }

        private Result(TError error)
        {
            IsSuccess = false;
            _error = error;
            _value = default;
        }

        public static Result<T, TError> Success(T value) =>
            new(value);

        public static Result<T, TError> Failure(TError error) =>
            new(error);
    }

    public readonly struct Result<TError>
    {
        private readonly TError? _error;

        public bool IsSuccess { get; }
        public bool IsFailure => !IsSuccess;

        public TError Error =>
            IsFailure
                ? _error!
                : throw new InvalidOperationException("Result does not contain an error.");

        private Result(bool isSuccess, TError? error)
        {
            IsSuccess = isSuccess;
            _error = error;
        }

        public static Result<TError> Success() =>
            new(true, default);

        public static Result<TError> Failure(TError error) =>
            new(false, error);
    }
}
