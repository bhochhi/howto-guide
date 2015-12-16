package com.codewithme.jndi;

import java.security.KeyStore.Entry.Attribute;
import java.util.Hashtable;
import java.util.Properties;

import javax.naming.Context;
import javax.naming.InitialContext;
import javax.naming.NamingEnumeration;
import javax.naming.NamingException;
import javax.naming.directory.Attributes;
//import com.sun.jndi.fs
import javax.naming.directory.DirContext;
import javax.naming.directory.InitialDirContext;
import javax.naming.directory.SearchControls;
import javax.naming.directory.SearchResult;
import javax.naming.ldap.InitialLdapContext;
import javax.naming.ldap.LdapContext;

/**
 * Hello world!
 *
 */
public class App {

	public static void main(String[] args) {

		// using properties to connect filesystem
		try {
			// Create a Properties object and set properties appropriately
			Properties props = new Properties();
			props.put(Context.INITIAL_CONTEXT_FACTORY, "com.sun.jndi.fscontext.RefFSContextFactory");
			props.put(Context.PROVIDER_URL, "file:///");

			// Create the initial context from the properties we just created
			Context initialContext = new InitialContext(props);

			// print all properties
			NamingEnumeration namingEnum = initialContext.list("");
			while (namingEnum.hasMore()) {
				System.out.println(namingEnum.next());
			}

		} catch (NamingException nnfe) {
			nnfe.printStackTrace();
			System.out.println("Encountered a naming exception");
		}

		// using hashtable to connect ldap
		try {
			// Create a Properties object and set properties appropriately
			Hashtable<String, String> env = new Hashtable<String, String>();
			env.put(Context.INITIAL_CONTEXT_FACTORY, "com.sun.jndi.ldap.LdapCtxFactory");
			env.put(Context.PROVIDER_URL, "ldap://ldap.host.com:port");
			env.put(Context.SECURITY_AUTHENTICATION, "simple");
			env.put(Context.SECURITY_PRINCIPAL, "username"); // specify the
																// username
			env.put(Context.SECURITY_CREDENTIALS, "password"); // specify the
																// password

			// Create the initial context from the properties we just created
			LdapContext initialContext = new InitialLdapContext(env, null);

			SearchControls searchControl = new SearchControls();
			searchControl.setSearchScope(SearchControls.SUBTREE_SCOPE);
			searchControl.setTimeLimit(30000);
			NamingEnumeration<?> namingEnum = initialContext.search("ou=bux,dc=host,dc=com",
					"(objectclass=user)", searchControl);
			while (namingEnum.hasMore()) {
				SearchResult result = (SearchResult) namingEnum.next();
				Attributes attrs = result.getAttributes();
				System.out.println(attrs.get("cn"));
			}

		} catch (NamingException nnfe) {
			nnfe.printStackTrace();
			System.out.println("Encountered a naming exception");
		}

	}
}
