﻿using System;
using System.Text;
using Hudl.FFmpeg.BaseTypes;
using Hudl.FFmpeg.Filters.BaseTypes;
using Hudl.FFmpeg.Resources.BaseTypes;

namespace Hudl.FFmpeg.Filters
{
    /// <summary>
    /// fps filter will set a frames per second on the stream, can be used on images as well
    /// </summary>
    [ForStream(Type = typeof(VideoStream))]
    public class Fps : BaseFilter
    {
        private const int FilterMaxInputs = 1;
        private const string FilterType = "fps";

        public Fps()
            : base(FilterType, FilterMaxInputs)
        {
        }
        public Fps(int? frameRate)
            : this()
        {
            FrameRate = frameRate;
        }

        public double? FrameRate { get; set; }

        public override void Validate()
        {
            if (FrameRate.HasValue && FrameRate <= 0)
            {
                throw new InvalidOperationException("FrameRate must be greater than zero.");
            }
        }

        public override string ToString()
        {
            var filterParameters = new StringBuilder(100);

            if (FrameRate.HasValue)
            {
                FilterUtility.ConcatenateParameter(filterParameters, FrameRate);
            }

            return FilterUtility.JoinTypeAndParameters(this, filterParameters);
        }
    }
}
