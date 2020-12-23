package crc64eef3a45c362233c8;


public class KtFunction0_1
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		kotlin.jvm.functions.Function0,
		kotlin.Function
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_invoke:()Ljava/lang/Object;:GetInvokeHandler:Kotlin.Jvm.Functions.IFunction0Invoker, Xamarin.Kotlin.StdLib\n" +
			"";
		mono.android.Runtime.register ("NL.DionSegijn.Konfetti.KtFunction0`1, DanielMartinus.Konfetti", KtFunction0_1.class, __md_methods);
	}


	public KtFunction0_1 ()
	{
		super ();
		if (getClass () == KtFunction0_1.class)
			mono.android.TypeManager.Activate ("NL.DionSegijn.Konfetti.KtFunction0`1, DanielMartinus.Konfetti", "", this, new java.lang.Object[] {  });
	}


	public java.lang.Object invoke ()
	{
		return n_invoke ();
	}

	private native java.lang.Object n_invoke ();

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
