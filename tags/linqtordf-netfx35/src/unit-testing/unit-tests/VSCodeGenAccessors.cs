﻿// ------------------------------------------------------------------------------
//<autogenerated>
//        This code was generated by Microsoft Visual Studio Team System 2005.
//
//        Changes to this file may cause incorrect behavior and will be lost if
//        the code is regenerated.
//</autogenerated>
//------------------------------------------------------------------------------
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RdfSerialisationTest
{
[System.Diagnostics.DebuggerStepThrough()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TestTools.UnitTestGeneration", "1.0.0.0")]
internal class BaseAccessor {
    
    protected Microsoft.VisualStudio.TestTools.UnitTesting.PrivateObject m_privateObject;
    
    protected BaseAccessor(object target, Microsoft.VisualStudio.TestTools.UnitTesting.PrivateType type) {
        m_privateObject = new Microsoft.VisualStudio.TestTools.UnitTesting.PrivateObject(target, type);
    }
    
    protected BaseAccessor(Microsoft.VisualStudio.TestTools.UnitTesting.PrivateType type) : 
            this(null, type) {
    }
    
    internal virtual object Target {
        get {
            return m_privateObject.Target;
        }
    }
    
    public override string ToString() {
        return this.Target.ToString();
    }
    
    public override bool Equals(object obj) {
        if (typeof(BaseAccessor).IsInstanceOfType(obj)) {
            obj = ((BaseAccessor)(obj)).Target;
        }
        return this.Target.Equals(obj);
    }
    
    public override int GetHashCode() {
        return this.Target.GetHashCode();
    }
}


[System.Diagnostics.DebuggerStepThrough()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TestTools.UnitTestGeneration", "1.0.0.0")]
internal class LinqToRdf_XsdtTypeConverterAccessor : BaseAccessor {
    
    protected static Microsoft.VisualStudio.TestTools.UnitTesting.PrivateType m_privateType = new Microsoft.VisualStudio.TestTools.UnitTesting.PrivateType(typeof(global::LinqToRdf.XsdtTypeConverter));
    
    internal LinqToRdf_XsdtTypeConverterAccessor(global::LinqToRdf.XsdtTypeConverter target) : 
            base(target, m_privateType) {
    }
    
    internal string GetXsdtDateRepresentationFor(global::System.DateTime d, global::LinqToRdf.XsdtPrimitiveDataType dt, global::LinqToRdf.XsdtAttribute attr) {
        object[] args = new object[] {
                d,
                dt,
                attr};
        string ret = ((string)(m_privateObject.Invoke("GetXsdtDateRepresentationFor", new System.Type[] {
                    typeof(global::System.DateTime),
                    typeof(global::LinqToRdf.XsdtPrimitiveDataType),
                    typeof(global::LinqToRdf.XsdtAttribute)}, args)));
        return ret;
    }
    
    internal global::LinqToRdf.XsdtAttribute GetXsdtAttrFor(global::LinqToRdf.XsdtPrimitiveDataType dt) {
        object[] args = new object[] {
                dt};
        global::LinqToRdf.XsdtAttribute ret = ((global::LinqToRdf.XsdtAttribute)(m_privateObject.Invoke("GetXsdtAttrFor", new System.Type[] {
                    typeof(global::LinqToRdf.XsdtPrimitiveDataType)}, args)));
        return ret;
    }
}
}
