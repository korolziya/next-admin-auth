"use server"

import { auth } from "@/auth"

const API_URL = "http://127.0.0.1:5000/api/menu";

export async function getMenu() {
    const session = await auth();
    if (!session?.accessToken) return [];

    try {
        const res = await fetch(API_URL, {
            headers: {
                "Authorization": `Bearer ${session.accessToken}`
            }
        });

        if (!res.ok) return [];

        return await res.json();
    } catch (error) {
        console.error("Menu fetch error:", error);
        return [];
    }
}

