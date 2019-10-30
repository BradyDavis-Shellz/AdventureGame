using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class AllConditionsTests
    {
        AllConditions sut;

        Condition requiredCondition;

        [SetUp]
        public void SetUp()
        {
            sut = ScriptableObject.CreateInstance<AllConditions>();
            requiredCondition = ScriptableObject.CreateInstance<Condition>();
        }

        [Test]
        public void AssertThatResetSetsAllConditionsToBeNotSatisfied()
        {
            int numConditions = Random.Range(1, 10);
            Condition[] conditions = new Condition[numConditions];

            for (int i = 0; i < numConditions; i++)
            {
                Condition condition = ScriptableObject.CreateInstance<Condition>();
                condition.satisfied = true;
                conditions[i] = condition;
            }

            sut.conditions = conditions;

            sut.Reset();

            for (int i = 0; i < sut.conditions.Length; i++)
            {
                Assert.IsFalse(sut.conditions[i].satisfied);
            }

        }

        [Test]
        public void AssertThatResetWithNoConditionsDoesNothing()
        {
            sut.Reset();

            Assert.IsNull(sut.conditions);
        }

        [Test]
        public void AssertThatCheckConditionReturnsFalseIfConditionsIsNull()
        {
            Assert.IsFalse(sut.CheckCondition(requiredCondition));
        }

        [Test]
        public void AssertThatCheckConditionReturnsFalseIfFirstConditionIsNull()
        {
            sut.conditions = new Condition[1];
            Assert.IsFalse(sut.CheckCondition(requiredCondition));
        }

        [Test]
        public void AssertThatCheckConditionReturnsFalseIfNoConditionsMatchRequiredConditionHash()
        {
            requiredCondition.hash = Random.Range(0, int.MaxValue);
            int numConditions = Random.Range(1, 10);
            sut.conditions = new Condition[numConditions];

            for (int i = 0; i < numConditions; i++)
            {
                Condition condition = ScriptableObject.CreateInstance<Condition>();
                condition.hash = Random.Range(0, int.MaxValue);
                sut.conditions[i] = condition;
            }

            Assert.IsFalse(sut.CheckCondition(requiredCondition));
        }

        [Test]
        public void AssertThatCheckConditionReturnsTrueWhenRequiredConditionSatisfiedIsSame()
        {
            requiredCondition.hash = Random.Range(0, int.MaxValue);
            int numConditions = Random.Range(1, 10);
            sut.conditions = new Condition[numConditions + 1];
            AllConditions.Instance = sut;

            for (int i = 0; i < numConditions; i++)
            {
                Condition condition = ScriptableObject.CreateInstance<Condition>();
                condition.hash = Random.Range(0, int.MaxValue);
                sut.conditions[i] = condition;
            }

            sut.conditions[numConditions] = requiredCondition;

            Assert.IsTrue(sut.CheckCondition(requiredCondition));
        }
    }
}
