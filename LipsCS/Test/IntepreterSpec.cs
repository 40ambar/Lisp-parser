﻿using Xunit;
using Source;
using System;

namespace Test {

    public class IntepreterSpec {

        private object Eval(Ast ast) {
            return ast.Eval(new Context());
        }

        [Fact]
        public void NumberTest(){
            Assert.Equal(
                Eval(new Literal(4.5)),
                4.5
            );
        } 

        [Fact]
        public void StringTest() {
            Assert.Equal(
                Eval(new Literal("40 ambar")),
                "40 ambar"
            );
        }

        [Fact]
        public void BooleanTest() {
            Assert.Equal(
                Eval(new Literal(true)),
                true
            );
        }

        [Fact]
        public void IfTest() {
            Assert.Equal(
                Eval(new If(new Literal(true), new Literal("dogru"), new Literal("yanlis"))),
                "dogru"
            );
            Assert.Equal(
                Eval(new If(new Literal(false), new Literal("dogru"), new Literal("yanlis"))),
                "yanlis"
            );
        }

        [Fact]
        public void LambdaCallTest() {
            Assert.Equal(Eval(
                new Call(
                    new Lambda(new[]{ "x", "y" }, new Literal("guzel")),
                    new Ast[]{ new Literal("x degeri") , new Literal("y degeri")}
                )
            ), "guzel");

            Assert.Equal(Eval(
                new Call(
                    new Lambda(new[]{ "x", "y" }, new Operator("+", new Literal(1.0), new Literal(2.0))),
                    new Ast[]{ new Literal(1.0) , new Literal(2.0) }
                )
            ), 3.0);
        }
    }
}