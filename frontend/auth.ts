import NextAuth from "next-auth"
import Credentials from "next-auth/providers/credentials"
import { authConfig } from "./auth.config"
import { LoginSchema } from "@/lib/schemas"

export const { auth, signIn, signOut, handlers } = NextAuth({
  ...authConfig,
  providers: [
    Credentials({
      async authorize(credentials) {
        console.log("!!! AUTHORIZE METODUNA GIRILDI !!!");
        
        const parsedCredentials = LoginSchema.safeParse(credentials)

        if (parsedCredentials.success) {
            try {
                const res = await fetch("http://127.0.0.1:5000/api/auth/login", {
                    method: 'POST',
                    body: JSON.stringify(parsedCredentials.data),
                    headers: { "Content-Type": "application/json" }
                })
                
                if (!res.ok) {
                    console.error("Backend login hatası:", res.status);
                    return null;
                }

                const user = await res.json()
                console.log("Backend'den gelen veri:", user);

                if (user) {
                    // Backend AuthResponseDto: { accessToken, refreshToken, firstName, lastName, companyName, companyLogo }
                    return {
                        id: user.accessToken, // NextAuth ID zorunlu kıldığı için token'ı kullanıyoruz
                        email: parsedCredentials.data.email,
                        firstName: user.firstName,
                        lastName: user.lastName,
                        role: user.role,
                        companyName: user.companyName,
                        companyLogo: user.companyLogo,
                        accessToken: user.accessToken,
                        refreshToken: user.refreshToken,
                        permissions: user.permissions
                    }
                }
            } catch (error) {
                console.error("Login işlemi hatası:", error)
            }
        }
        return null
      },
    }),
  ],
  callbacks: {
    async jwt({ token, user }) {
      // İlk giriş anında (user doluysa) bilgileri token'a at
      if (user) {
        return {
            ...token,
            firstName: (user as any).firstName,
            lastName: (user as any).lastName,
            role: (user as any).role,
            companyName: (user as any).companyName,
            companyLogo: (user as any).companyLogo,
            accessToken: (user as any).accessToken,
            refreshToken: (user as any).refreshToken,
            permissions: (user as any).permissions,
        }
      }
      return token
    },
    async session({ session, token }) {
      // Token'dan session'a aktar
      if (token) {
        (session.user as any).firstName = token.firstName;
        (session.user as any).lastName = token.lastName;
        (session.user as any).role = token.role;
        (session.user as any).companyName = token.companyName;
        (session.user as any).companyLogo = token.companyLogo;
        (session as any).accessToken = token.accessToken;
        (session as any).refreshToken = token.refreshToken;
        (session.user as any).permissions = token.permissions;
      }
      return session
    }
  }
})
