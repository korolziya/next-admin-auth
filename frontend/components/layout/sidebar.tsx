"use client"

import Link from "next/link"
import { usePathname } from "next/navigation"
import { cn } from "@/lib/utils"
import { LayoutDashboard, Users, Settings, LucideIcon, ChevronDown, ChevronRight, User } from "lucide-react"
import { useState } from "react"

const iconMap: Record<string, LucideIcon> = {
    LayoutDashboard,
    Users,
    Settings,
    User
};

interface MenuItem {
    id: string;
    title: string;
    path: string;
    icon: string;
    children?: MenuItem[];
}

interface SidebarProps {
    menuItems: MenuItem[];
    companyName?: string;
    className?: string;
}

export function Sidebar({ menuItems, companyName, className }: SidebarProps) {
    return (
        <div className={cn("pb-12 border-r bg-background h-full", className)}>
            <div className="space-y-4 py-4">
                <div className="px-3 py-2">
                    <h2 className="mb-2 px-4 text-lg font-semibold tracking-tight">
                        {companyName || "Admin Panel"}
                    </h2>
                    <div className="space-y-1">
                        {menuItems.map((item) => (
                            <SidebarItem key={item.id} item={item} />
                        ))}
                    </div>
                </div>
            </div>
        </div>
    )
}

function SidebarItem({ item, level = 0 }: { item: MenuItem; level?: number }) {
    const pathname = usePathname();
    const Icon = iconMap[item.icon] || LayoutDashboard;
    const hasChildren = item.children && item.children.length > 0;
    const [isOpen, setIsOpen] = useState(false); // Varsayılan kapalı olsun

    // Eğer child items'dan biri aktifse, parent'ı açık tutabiliriz (opsiyonel)
    // const isActiveChild = hasChildren && item.children!.some(c => c.path === pathname);
    
    const isActive = pathname === item.path;

    if (hasChildren) {
        return (
            <div>
                <button
                    onClick={() => setIsOpen(!isOpen)}
                    className={cn(
                        "group flex w-full items-center justify-between rounded-md px-3 py-2 text-sm font-medium hover:bg-accent hover:text-accent-foreground",
                        "text-muted-foreground"
                    )}
                    style={{ paddingLeft: `${level * 12 + 12}px` }}
                >
                    <div className="flex items-center">
                        <Icon className="mr-2 h-4 w-4" />
                        <span>{item.title}</span>
                    </div>
                    {isOpen ? <ChevronDown className="h-4 w-4" /> : <ChevronRight className="h-4 w-4" />}
                </button>
                {isOpen && (
                    <div className="mt-1 space-y-1">
                        {item.children!.map((child) => (
                            <SidebarItem key={child.id} item={child} level={level + 1} />
                        ))}
                    </div>
                )}
            </div>
        );
    }

    return (
        <Link
            href={item.path}
            className={cn(
                "group flex items-center rounded-md px-3 py-2 text-sm font-medium hover:bg-accent hover:text-accent-foreground",
                isActive ? "bg-accent text-accent-foreground" : "text-muted-foreground"
            )}
            style={{ paddingLeft: `${level * 12 + 12}px` }}
        >
            <Icon className="mr-2 h-4 w-4" />
            <span>{item.title}</span>
        </Link>
    )
}
