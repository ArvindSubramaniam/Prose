﻿using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.ProgramSynthesis;
using Microsoft.ProgramSynthesis.Learning;
using Microsoft.ProgramSynthesis.Rules;
using Microsoft.ProgramSynthesis.Specifications;

namespace ProseTutorial
{
    public class WitnessFunctions : DomainLearningLogic
    {
        public WitnessFunctions(Grammar grammar) : base(grammar)
        {
        }

        [WitnessFunction(nameof(Semantics.add), 1)]
        public ExampleSpec WitnessStartPosition(GrammarRule rule, ExampleSpec spec)
        {
            var result = new Dictionary<State, object>();

            foreach (KeyValuePair<State, object> example in spec.Examples)
            {
                State inputState = example.Key;
                var input = inputState[rule.Body[0]] as int[];
                // foreach(int i in input)
                // Console.WriteLine(i);
                var output = example.Value as int[];
                int refinedExample = input.IndexOf(output);
                Console.WriteLine(refinedExample);
                result[inputState] = refinedExample;
            }
            return new ExampleSpec(result);
        }

        [WitnessFunction(nameof(Semantics.add), 2)]
        public ExampleSpec WitnessEndPosition(GrammarRule rule, ExampleSpec spec)
        {
            var result = new Dictionary<State, object>();
            foreach (KeyValuePair<State, object> example in spec.Examples)
            {
                State inputState = example.Key;
                var input = inputState[rule.Body[0]] as int[];
                var output = example.Value as int[];
                int refinedExample = input.IndexOf(output) + output.Length;
                result[inputState] = refinedExample;
            }
            return new ExampleSpec(result);
        }

        [WitnessFunction(nameof(Semantics.AbsPos), 1)]
        public ExampleSpec WitnessK(GrammarRule rule, ExampleSpec spec)
        {
            var result = new Dictionary<State, object>();
            foreach (KeyValuePair<State, object> example in spec.Examples)
            {
                State inputState = example.Key;
                var v = inputState[rule.Body[0]] as int[];
                var pos = (int) example.Value;
                result[inputState] = pos + 1;
            }
            return new ExampleSpec(result);
        }
    }
}
