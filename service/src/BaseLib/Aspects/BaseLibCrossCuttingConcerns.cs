using BaseLib.Services;
using System;

namespace BaseLib.Aspects
{
    /// <summary>
    /// BaseLibCrossCuttingConcerns
    /// </summary>
    internal class BaseLibCrossCuttingConcerns
    {
        public const string Validation = "BaseLibValidation";
        public const string UnitOfWork = "BaseLibUnitOfWork";

        public static void AddApplied(object obj, params string[] concerns)
        {
            if (concerns.IsNullOrEmpty())
            {
                throw new ArgumentNullException(nameof(concerns), $"{nameof(concerns)} should be provided!");
            }

            (obj as IAvoidDuplicateCrossCuttingConcerns)?.AppliedCrossCuttingConcerns.AddRange(concerns);
        }

        public static void RemoveApplied(object obj, params string[] concerns)
        {
            if (concerns.IsNullOrEmpty())
            {
                throw new ArgumentNullException(nameof(concerns), $"{nameof(concerns)} should be provided!");
            }
            if (obj is IAvoidDuplicateCrossCuttingConcerns avoidDuplicateCrossCuttingConcerns)
            {
                foreach (string concern in concerns)
                {
                    avoidDuplicateCrossCuttingConcerns.AppliedCrossCuttingConcerns.RemoveAll((string c) => c == concern);
                }
            }
        }

        public static bool IsApplied(object obj, string concern)
        {
            if (obj == null)
            {
                throw new ArgumentNullException("obj");
            }
            if (concern == null)
            {
                throw new ArgumentNullException("concern");
            }
            return (obj as IAvoidDuplicateCrossCuttingConcerns)?.AppliedCrossCuttingConcerns.Contains(concern) ?? false;
        }

        public static IDisposable Applying(object obj, params string[] concerns)
        {
            AddApplied(obj, concerns);
            return new DisposeAction(() =>
            {
                RemoveApplied(obj, concerns);
            });
        }

        public static string[] GetApplieds(object obj)
        {
            if (!(obj is IAvoidDuplicateCrossCuttingConcerns crossCuttingEnabledObj))
            {
                return new string[0];
            }

            return crossCuttingEnabledObj.AppliedCrossCuttingConcerns.ToArray();
        }
    }
}