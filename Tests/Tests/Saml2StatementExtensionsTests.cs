﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IdentityModel.Tokens;
using FluentAssertions;
using System.Collections.Generic;
using System.Security.Claims;

namespace Sustainsys.Saml2.Tests
{
    [TestClass]
    public class Saml2StatementExtensionsTests
    {
        [TestMethod]
        public void Saml2StatementExtensions_ToXElement_NullCheck()
        {
            Saml2Statement assertion = null;

            Action a = () => assertion.ToXElement();

            a.ShouldThrow<ArgumentNullException>().And.ParamName.Should().Be("statement");
        }

        [TestMethod]
        public void Saml2StatementExtensions_ToXElement_TypeCheck()
        {
            Saml2Statement assertion = new StubSaml2Statement();

            Action a = () => assertion.ToXElement();

            a.ShouldThrow<NotImplementedException>()
                .And.Message.Should().Be("Statement of type StubSaml2Statement is not supported.");
        }

        private class StubSaml2Statement : Saml2Statement
        {
        }
    }
}
