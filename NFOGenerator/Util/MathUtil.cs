/// Copyright 2017 Troy Lewis. All Rights Reserved
/// 
/// Licensed under the Apache License, Version 2.0 (the "License");
/// you may not use this file except in compliance with the License.
/// You may obtain a copy of the License at
/// 
///     http://www.apache.org/licenses/LICENSE-2.0
/// 
/// Unless required by applicable law or agreed to in writing, software
/// distributed under the License is distributed on an "AS IS" BASIS,
/// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
/// See the License for the specific language governing permissions and
/// limitations under the License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NFOGenerator.Util
{
    /// <summary>
    /// Utilities about math
    /// </summary>
    public class MathUtil
    {
        /// <summary>
        /// Get the variance of a list
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public static double GetVariance(List<double> a)
        {
            double var = 0;
            double avrg = a.Average();
            foreach (double x in a)
            {
                var += (x - avrg) * (x - avrg);
            }
            return var / a.Count;
        }
    }
}
