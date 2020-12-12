using System;
namespace transport_problem.exceptions
{
    public class MalformedProblemTableException: Exception {
        public String message;

        public MalformedProblemTableException(String message) {
            this.message = message;
        }

    }

    public class InternalCalculationError: Exception { }

    public class InvalidValueSpecified: Exception { }

    public class InvalidTableRangeInput: Exception { }
}
