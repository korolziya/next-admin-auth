"use client"

import { useState, useRef, useEffect } from "react"
import { LogOut, Settings, User as UserIcon } from "lucide-react"
import { logout } from "@/actions/auth-actions"

interface HeaderProps {
    user: {
        name: string;
        email: string;
        companyLogo?: string;
    }
}

export function Header({ user }: HeaderProps) {
    const [isOpen, setIsOpen] = useState(false);
    const dropdownRef = useRef<HTMLDivElement>(null);

    useEffect(() => {
        function handleClickOutside(event: MouseEvent) {
            if (dropdownRef.current && !dropdownRef.current.contains(event.target as Node)) {
                setIsOpen(false);
            }
        }
        document.addEventListener("mousedown", handleClickOutside);
        return () => document.removeEventListener("mousedown", handleClickOutside);
    }, []);

    return (
        <header className="border-b bg-background">
            <div className="flex h-16 items-center px-4 gap-4">
                {/* Search Bar (Placeholder) */}
                <div className="flex-1">
                    <input 
                        type="text" 
                        placeholder="Search..." 
                        className="h-9 md:w-[300px] w-full rounded-md border border-input bg-transparent px-3 py-1 text-sm shadow-sm transition-colors file:border-0 file:bg-transparent file:text-sm file:font-medium placeholder:text-muted-foreground focus-visible:outline-none focus-visible:ring-1 focus-visible:ring-ring disabled:cursor-not-allowed disabled:opacity-50"
                    />
                </div>

                {/* User Nav */}
                <div className="flex items-center gap-4">
                    <div className="relative" ref={dropdownRef}>
                        <button 
                            onClick={() => setIsOpen(!isOpen)}
                            className="relative h-8 w-8 rounded-full bg-muted flex items-center justify-center overflow-hidden focus:outline-none focus:ring-2 focus:ring-ring focus:ring-offset-2"
                        >
                             {user.companyLogo ? (
                                <img 
                                    src={`http://localhost:5000${user.companyLogo}`} 
                                    alt="Avatar" 
                                    className="h-full w-full object-cover"
                                />
                            ) : (
                                <span className="text-xs font-medium text-muted-foreground">
                                    {user.name.substring(0, 2).toUpperCase()}
                                </span>
                            )}
                        </button>

                         {isOpen && (
                            <div className="absolute right-0 mt-2 w-56 origin-top-right rounded-md border bg-popover text-popover-foreground shadow-md outline-none animate-in fade-in-80 z-50">
                                <div className="flex flex-col space-y-1 p-2 border-b">
                                    <p className="text-sm font-medium leading-none">{user.name}</p>
                                    <p className="text-xs leading-none text-muted-foreground">{user.email}</p>
                                </div>
                                <div className="p-1">
                                    <a href="#" className="relative flex cursor-default select-none items-center rounded-sm px-2 py-1.5 text-sm outline-none hover:bg-accent hover:text-accent-foreground">
                                        <UserIcon className="mr-2 h-4 w-4" />
                                        <span>Profil</span>
                                    </a>
                                    <a href="#" className="relative flex cursor-default select-none items-center rounded-sm px-2 py-1.5 text-sm outline-none hover:bg-accent hover:text-accent-foreground">
                                        <Settings className="mr-2 h-4 w-4" />
                                        <span>Ayarlar</span>
                                    </a>
                                </div>
                                <div className="border-t p-1">
                                    <button 
                                        onClick={() => logout()}
                                        className="relative flex w-full cursor-default select-none items-center rounded-sm px-2 py-1.5 text-sm outline-none hover:bg-destructive/10 text-destructive hover:text-destructive font-medium"
                                    >
                                        <LogOut className="mr-2 h-4 w-4" />
                                        <span>Çıkış Yap</span>
                                    </button>
                                </div>
                            </div>
                        )}
                    </div>
                </div>
            </div>
        </header>
    )
}
