import NextAuth, { DefaultSession } from "next-auth"
import { JWT } from "next-auth/jwt"

export interface Permission {
  screenCode: string
  canRead: boolean
  canCreate: boolean
  canUpdate: boolean
  canDelete: boolean
}

declare module "next-auth" {
  interface Session {
    user: {
      firstName: string
      lastName: string
      role: string
      companyName: string
      companyLogo?: string
      accessToken: string
      refreshToken: string
      permissions: Permission[]
    } & DefaultSession["user"]
  }

  interface User {
    firstName: string
    lastName: string
    role: string
    companyName: string
    companyLogo?: string
    accessToken: string
    refreshToken: string
    permissions: Permission[]
  }
}

declare module "next-auth/jwt" {
  interface JWT {
    firstName: string
    lastName: string
    role: string
    companyName: string
    companyLogo?: string
    accessToken: string
    refreshToken: string
    permissions: Permission[]
  }
}

